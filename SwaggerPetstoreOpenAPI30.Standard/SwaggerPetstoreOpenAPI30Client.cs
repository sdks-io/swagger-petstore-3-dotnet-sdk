// <copyright file="SwaggerPetstoreOpenAPI30Client.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstoreOpenAPI30.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using APIMatic.Core;
    using APIMatic.Core.Authentication;
    using APIMatic.Core.Types;
    using SwaggerPetstoreOpenAPI30.Standard.Authentication;
    using SwaggerPetstoreOpenAPI30.Standard.Controllers;
    using SwaggerPetstoreOpenAPI30.Standard.Http.Client;
    using SwaggerPetstoreOpenAPI30.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class SwaggerPetstoreOpenAPI30Client : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://petstore3.swagger.io/api/v3" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly HttpCallBack httpCallBack;
        private readonly CustomHeaderAuthenticationManager customHeaderAuthenticationManager;
        private readonly Lazy<PetController> pet;
        private readonly Lazy<StoreController> store;
        private readonly Lazy<UserController> user;

        private SwaggerPetstoreOpenAPI30Client(
            Environment environment,
            string apiKey,
            HttpCallBack httpCallBack,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallBack = httpCallBack;
            this.HttpClientConfiguration = httpClientConfiguration;
            customHeaderAuthenticationManager = new CustomHeaderAuthenticationManager(apiKey);
            globalConfiguration = new GlobalConfiguration.Builder()
                .AuthManagers(new Dictionary<string, AuthManager> {
                        {"global", customHeaderAuthenticationManager}
                })
                .ApiCallback(httpCallBack)
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .UserAgent(userAgent)
                .Build();


            this.pet = new Lazy<PetController>(
                () => new PetController(globalConfiguration));
            this.store = new Lazy<StoreController>(
                () => new StoreController(globalConfiguration));
            this.user = new Lazy<UserController>(
                () => new UserController(globalConfiguration));
        }

        /// <summary>
        /// Gets PetController controller.
        /// </summary>
        public PetController PetController => this.pet.Value;

        /// <summary>
        /// Gets StoreController controller.
        /// </summary>
        public StoreController StoreController => this.store.Value;

        /// <summary>
        /// Gets UserController controller.
        /// </summary>
        public UserController UserController => this.user.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the credentials to use with CustomHeaderAuthentication.
        /// </summary>
        public ICustomHeaderAuthenticationCredentials CustomHeaderAuthenticationCredentials => this.customHeaderAuthenticationManager;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the SwaggerPetstoreOpenAPI30Client using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .CustomHeaderAuthenticationCredentials(customHeaderAuthenticationManager.ApiKey)
                .HttpCallBack(httpCallBack)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> SwaggerPetstoreOpenAPI30Client.</returns>
        internal static SwaggerPetstoreOpenAPI30Client CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_OPEN_API_30_STANDARD_ENVIRONMENT");
            string apiKey = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_OPEN_API_30_STANDARD_API_KEY");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (apiKey != null)
            {
                builder.CustomHeaderAuthenticationCredentials(apiKey);
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = SwaggerPetstoreOpenAPI30.Standard.Environment.Production;
            private string apiKey = "";
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private HttpCallBack httpCallBack;

            /// <summary>
            /// Sets credentials for CustomHeaderAuthentication.
            /// </summary>
            /// <param name="apiKey">ApiKey.</param>
            /// <returns>Builder.</returns>
            public Builder CustomHeaderAuthenticationCredentials(string apiKey)
            {
                this.apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

           

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            /// <param name="httpCallBack"> http callback. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

            /// <summary>
            /// Creates an object of the SwaggerPetstoreOpenAPI30Client using the values provided for the builder.
            /// </summary>
            /// <returns>SwaggerPetstoreOpenAPI30Client.</returns>
            public SwaggerPetstoreOpenAPI30Client Build()
            {

                return new SwaggerPetstoreOpenAPI30Client(
                    environment,
                    apiKey,
                    httpCallBack,
                    httpClientConfig.Build());
            }
        }
    }
}
