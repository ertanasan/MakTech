// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { GamePlay } from '@gamification/model/game-play.model';
import { GamePlayService } from '@gamification/service/game-play.service';
import { GamePlayEditComponent } from '@gamification/screen/game-play/game-play-edit/game-play-edit.component';
import { GameService } from '@gamification/service/game.service';
import { GameLevelService } from '@gamification/service/game-level.service';
import { GameQuestion } from '@gamification/model/game-question.model';
import { QuestionChoice } from '@gamification/model/question-choice.model';
import { GameLevel } from '@gamification/model/game-level.model';
import { GamePlayAnswer } from '@gamification/model/game-play-answer.model';
import { GamePlayAnswerService } from '@gamification/service/game-play-answer.service';
import { ListParams } from '@otmodel/list-params.model';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import { Observable, Subscription } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';
import { GamePlayerService } from '@gamification/service/game-player.service';
import { GamePlayer } from '@gamification/model/game-player.model';
import { GameScore } from '@gamification/model/game.model';
import * as _ from 'lodash';
import { process } from '@progress/kendo-data-query';
import { OrganizationService } from '@frame/organization/service/organization.service';
import { BranchService } from '@frame/organization/service/branch.service';
import { first } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-play-list',
    templateUrl: './game-play-list.component.html',
    styleUrls: ['./game-play-list.component.css', ]
})
export class GamePlayListComponent extends ListScreenBase<GamePlay> implements OnInit, OnDestroy {
    @ViewChild(GamePlayEditComponent, {static: true}) editScreen: GamePlayEditComponent;

    contextState$: Observable<OTContext>;
    contextInfo;
    gameName: string;
    gameCaption: string;
    screenNo: number;
    questionList: GameQuestion[];
    levelQuestionNo: number;
    totalQuestionCount: number;
    choice1: QuestionChoice;
    choice2: QuestionChoice;
    choice3: QuestionChoice;
    choice4: QuestionChoice;
    timerHolder: any;
    gameStart = false;
    gameTimer: number;
    gameErrorCount: number;
    gameScore: number;
    levelList: GameLevel[];
    level: GameLevel;
    currentLevel: number;
    class1: string;
    class2: string;
    class3: string;
    class4: string;
    choice1disable: boolean;
    choice2disable: boolean;
    choice3disable: boolean;
    choice4disable: boolean;
    emptyclass = 'btn btn-light btn-lg btn-block';
    errorclass = 'btn btn-danger btn-lg btn-block';
    successclass = 'btn btn-success btn-lg btn-block';
    currentPlay: GamePlay;
    player: GamePlayer;
    scores: GameScore[];
    dayRank: number;
    weekRank: number;
    monthRank: number;
    rankList: any;
    gamer: boolean;
    playerBranchId: any;
    playerName = '';
    dayChamps: any;
    monthChamps: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        private changeDetectorRef: ChangeDetectorRef,
        public utilityService: OTUtilityService,
        public dataService: GamePlayService,
        public gameService: GameService,
        public gameLevelService: GameLevelService,
        public gamePlayerService: GamePlayerService,
        public gamePlayAnswerService: GamePlayAnswerService,
        public utilityMethods: OverstoreCommonMethods,
        public branchService: BranchService,
        private store: Store<fromApp.AppState>,
    ) {
        super(messageService, translateService);

        this.contextState$ = this.store.select('context');
    }

    refreshList() {

    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Gamification' }, {Caption: this.gameCaption, RouterLink: '/gamification/game-play'}];
    }

    createEmptyModel(): GamePlay {
        return new GamePlay();
    }


    /*Section="CustomCodeRegion"*/
    //#region Customized
    gameOver() {
        // game bilgilerini update et.
        this.totalQuestionCount += this.levelQuestionNo;
        this.currentPlay.EndTime = this.utilityMethods.addHours(new Date(), 3);
        this.currentPlay.QuestionCount = this.totalQuestionCount;
        this.currentPlay.LastLevel = this.level.GameLevelId;
        this.currentPlay.Score = this.gameScore;
        this.dataService.update(this.currentPlay).subscribe(() => {
            this.dataService.listScores().subscribe(res => {
                this.scores = res;
                this.dayRank = _.filter(_.filter(this.scores, ['DayGroup', 'Bugün']), ['PlayerId', this.player.GamePlayerId])[0].RowNumber;
                this.weekRank = _.filter(_.filter(this.scores, ['DayGroup', 'Bu Hafta']), ['PlayerId', this.player.GamePlayerId])[0].RowNumber;
                this.monthRank = _.filter(_.filter(this.scores, ['DayGroup', 'Bu Ay']), ['PlayerId', this.player.GamePlayerId])[0].RowNumber;
            });
        });
        this.gameStart = false;
        setTimeout(() => {
            this.screenNo = 3;
            this.gameCaption = this.gameName;
        }, 3000);
    }

    setTimer() {
        if (this.gameStart && this.gameTimer === 0) {
            if (this.gameErrorCount === 0) {
                this.gameOver();
                this.messageService.warning('Oyun bitti');
            } else {
                this.gameTimer = this.level.Duration;
                this.gameErrorCount = this.gameErrorCount - 1;
            }
        } else if (this.gameStart) {
            this.gameTimer -= 1;
        }
    }

    ngOnInit() {

        this.branchService.listAll();

        this.contextState$.pipe(first()).subscribe(
            context => {
                this.contextInfo = context;
                // console.log(this.contextInfo);
                this.gamer = (this.contextInfo.User.Name === 'oyuncu');
                // console.log(this.gamer);
                if (!this.gamer) {
                    this.gamePlayerService.readPlayerId(this.contextInfo.User.Id, 0, '').subscribe (res => {
                        this.player = res;
                    });
                } else {
                    this.player = null;
                }
            }
        );

        this.dataService.listScores().subscribe(res => {
            this.scores = res;
            const lp: ListParams = new ListParams();
            lp.take = 3;
            this.dayChamps = process(_.sortBy(_.filter(this.scores, ['DayGroup', 'Bugün']), 'RowNumber'), lp);
            this.monthChamps = process(_.sortBy(_.filter(this.scores, ['DayGroup', 'Bu Ay']), 'RowNumber'), lp);
        });

        this.screenNo = 1;
        this.gameService.read(1).subscribe(result => {
            this.gameName = result.GameName;
            this.gameCaption = result.GameName;
        });
        this.timerHolder = setInterval(() => {
            this.setTimer();
            this.changeDetectorRef.markForCheck();
        }, 1000); // 1 second
    }

    ngOnDestroy(): void {
        clearInterval(this.timerHolder);
    }

    newQuestion() {
        this.gameCaption = `${this.gameName} - Seviye : ${this.level.LevelCode} - Soru : ${this.levelQuestionNo + 1}`;
        const gq: GameQuestion = this.questionList[this.levelQuestionNo];
        const randomValue = Math.floor(Math.random() * 4) + 1;
        this.choice1 = gq.Choices[(randomValue + 0) % 4];
        this.choice2 = gq.Choices[(randomValue + 1) % 4];
        this.choice3 = gq.Choices[(randomValue + 2) % 4];
        this.choice4 = gq.Choices[(randomValue + 3) % 4];
        this.class1 = this.emptyclass;
        this.class2 = this.emptyclass;
        this.class3 = this.emptyclass;
        this.class4 = this.emptyclass;
        this.choice1disable = false;
        this.choice2disable = false;
        this.choice3disable = false;
        this.choice4disable = false;
        this.gameTimer = this.level.Duration;
    }

    newLevel() {
        // yeni soruları al
        this.totalQuestionCount += this.level.QuestionCount;
        this.currentLevel += 1;
        if (this.currentLevel < this.levelList.length) {
            // console.log('new level ', this.currentLevel);
            this.level = this.levelList[this.currentLevel];
            this.dataService.listPlayLevelQuestions(this.currentPlay.GamePlayId, this.level.MinDifficultyLevel, this.level.MaxDifficultyLevel, this.level.QuestionCount).subscribe(list => {
                // console.log(list);
                this.questionList = list;
                this.levelQuestionNo = 0;
                this.gameErrorCount = this.level.LevelErrorTolerance;
                this.newQuestion();
            });
        } else {
            // console.log('new level game over');
            this.gameOver();
            this.messageService.success('Oyunu tamamladınız. Tebrikler');
        }
    }

    insertAnswer (answerChoice: number, result: boolean) {
        const model: GamePlayAnswer = new GamePlayAnswer();
        model.Organization = 1;
        model.Play = this.currentPlay.GamePlayId;
        model.Question = this.questionList[this.levelQuestionNo].GameQuestionId;
        model.AnswerChoice = answerChoice;
        model.ResultFlag = result;
        this.gamePlayAnswerService.create(model).subscribe(() => {});
    }

    onSelected(selection: QuestionChoice, btn: number) {
        if (selection.RightAnswer) {
            this.insertAnswer(selection.QuestionChoiceId, true);
            this.choice1disable = true;
            this.choice2disable = true;
            this.choice3disable = true;
            this.choice4disable = true;
            switch (btn) {
                case 1 : this.class1 = this.successclass; break;
                case 2 : this.class2 = this.successclass; break;
                case 3 : this.class3 = this.successclass; break;
                case 4 : this.class4 = this.successclass; break;
            }
            setTimeout(() => {
                this.gameScore += this.level.PointofRightAnswer;
                if ((this.levelQuestionNo + 1) >= this.level.QuestionCount) {
                    this.newLevel();
                } else {
                    this.levelQuestionNo += 1;
                    this.newQuestion();
                }
            }, 1000);
        } else {
            this.insertAnswer(selection.QuestionChoiceId, false);
            switch (btn) {
                case 1 : this.class1 = this.errorclass; this.choice1disable = true; break;
                case 2 : this.class2 = this.errorclass; this.choice2disable = true; break;
                case 3 : this.class3 = this.errorclass; this.choice3disable = true; break;
                case 4 : this.class4 = this.errorclass; this.choice4disable = true; break;
            }
            if (this.gameErrorCount === 0) {
                this.gameOver();
                this.messageService.warning('Oyun bitti');
            } else {
                this.gameErrorCount -= 1;
            }
        }
    }

    startGame() {
        this.gameLevelService.listAllByMasterAsync(1).subscribe(result => {
            this.levelList = result;
            // console.log(this.levelList);
            this.currentLevel = 0;
            this.level = this.levelList[this.currentLevel];
            // console.log(this.level);
            const model: GamePlay = new GamePlay();
            model.Organization = 1;
            model.Game = 1;
            model.Player = this.player.GamePlayerId;
            model.LastLevel = 0;
            model.StartTime = this.utilityMethods.addHours(new Date(), 3);
            model.Score = 0;
            this.dataService.create(model).subscribe(newPlay => {
                this.currentPlay = newPlay;
                this.dataService.listPlayLevelQuestions(this.currentPlay.GamePlayId, this.level.MinDifficultyLevel, this.level.MaxDifficultyLevel, this.level.QuestionCount).subscribe(list => {
                    // console.log(list);
                    this.questionList = list;
                    this.screenNo = 2;
                    this.levelQuestionNo = 0;
                    this.gameStart = true;
                    this.gameScore = 0;
                    this.totalQuestionCount = 0;
                    this.gameErrorCount = this.level.LevelErrorTolerance;
                    this.newQuestion();
                });
            });
        });
    }

    onStart() {
        if (!this.player && this.playerName.length === 0) {
            this.messageService.warning('Ad Soyadınızı giriniz.');
            return;
        }
        if (!this.player && !this.playerBranchId) {
            this.messageService.warning('Biriminizi seçiniz.');
            return;
        }
        if (this.gamer) {
            this.gamePlayerService.readPlayerId(0, this.playerBranchId.BranchId, this.playerName).subscribe (res => {
                this.player = res;
                this.startGame();
            });
        } else {
            this.startGame();
        }
    }

    onOK() {
        this.screenNo = 1;
    }

    onScoreClicked(groupNo) {
        let groupName: string;
        switch (groupNo) {
            case 1: groupName = 'Bugün'; break;
            case 2: groupName = 'Bu Hafta'; break;
            case 3: groupName = 'Bu Ay'; break;
        }
        const lp: ListParams = new ListParams();
        lp.take = 100;
        this.rankList = process(_.sortBy(_.filter(this.scores, ['DayGroup', groupName]), 'RowNumber'), lp);
        this.screenNo = 4;
    }

    onBack() {
        this.screenNo = 3;
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
