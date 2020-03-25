export class LoginResult {
    constructor(public AccessToken: string,
                public RefreshToken: string,
                public ExpireInSeconds: number,
                public UserId: number,
                public UserFullName: string,
                public UserName: string,
                public UserEmail: string,
                public Gender: string,
                public PasswordExpired = false,
                public TokenDate: Date,
                public RefreshTokenExpireInSeconds = 100
            ) {

    }
}
