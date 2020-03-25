-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_INS_ESTATELANDLORD_SP
    @EstateRent    INT,
    @Landlord      INT,
    @OwnershipRate NUMERIC(5,2),
    @PaymentRate   NUMERIC(5,2),
    @IBAN          VARCHAR(50)
AS
BEGIN
    /*Section="Insert"*/
    -- Insert record
    SET NOCOUNT OFF
    INSERT INTO FIN_ESTATELANDLORD
    (
        ESTATERENT,
        LANDLORD,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        OWNERSHIP_RT,
        PAYMENT_RT,
        IBAN_TXT
    )
    VALUES
    (
        @EstateRent,
        @Landlord,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @OwnershipRate,
        @PaymentRate,
        @IBAN
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
END;
