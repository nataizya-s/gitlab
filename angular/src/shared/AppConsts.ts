export class AppConsts {

    static remoteServiceBaseUrl: string;
    static appBaseUrl: string;
    static appBaseHref: string; // returns angular's base-href parameter value if used during the publish

    static localeMappings: any = [];

    static readonly userManagement = {
        defaultAdminUserName: 'admin'
    };

    static readonly localization = {
        defaultLocalizationSourceName: 'EduVault'
    };

    static readonly authorization = {
        encryptedAuthTokenName: 'enc_auth_token'
    };

    static readonly contactTypes = [{ id: 1, value: "Cell Phone" }, { id: 2, value: "Landline" }, { id: 3, value: "Fax" }, { id: 4, value: "Email Address" }];
    static readonly addressTypes = [{ id: 1, value: "Home" }, { id: 2, value: "Business" }, { id: 3, value: "Billing" }, { id: 4, value: "Shipping" }, { id: 5, value: "Not Applicable" }];

}
