using System;
using System.Collections.Generic;
using System.Web;
using DotNetOpenAuth.AspNet;
using DotNetOpenAuth.AspNet.Clients;
using Microsoft.Web.WebPages.OAuth;

namespace TestStubMVC4.App_Start {
    public static class AuthConfig {
        public static void RegisterAuth() {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            OAuthWebSecurity.RegisterGoogleClient();
            OAuthWebSecurity.RegisterClient(new MockClient(), "Mock OpenID Client", new Dictionary<string, object>());
        }
    }

    public class MockClient : OpenIdClient {
        public MockClient()
            : base("mockclient", "https://localhost:5555") {

        }
    }
}
