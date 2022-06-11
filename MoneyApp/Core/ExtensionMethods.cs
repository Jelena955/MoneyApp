using Application.Commands;
using Application.Commands.Account;
using Application.Commands.Currency;
using Application.Commands.PaymentCategory;
using Application.Commands.Payments;
using Application.Commands.PaymentType;
using Application.Commands.UseCase;
using Application.Commands.User;
using Application.Core;
using Application.Queries;
using Application.Queries.Account;
using Application.Queries.Currency;
using Application.Queries.PaymentCategory;
using Application.Queries.Payments;
using Application.Queries.PaymentType;
using Application.Queries.TraceObject;
using Application.Queries.UseCase;
using Implementation.Commands.EF.AccountCommands;
using Implementation.Commands.EF.Currency;
using Implementation.Commands.EF.PaymentsCommands;
using Implementation.Commands.EF.UseCaseCommands;
using Implementation.Commands.EF.UseCaseValidators;
using Implementation.Commands.EF.UserCommands;
using Implementation.Queries;
using Implementation.Queries.EF;
using Implementation.Queries.EF.AccountQueries;
using Implementation.Queries.EF.CurrencyQueries;
using Implementation.Queries.EF.PaymentsQueries;
using Implementation.Queries.EF.UseCaseQueries;
using Implementation.Validators;
using Implementation.Validators.CurrencyValidators;
using Implementation.Validators.PaymentValidators;
using Implementation.Validators.UseCaseValidators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json;

namespace MoneyApp.Core
{
    public static class ExtensionMethods
    {//Next number: 30
        public static void AddQueriesUseCases(this IServiceCollection services)
        {
            services.AddTransient<IGetAllAccounts, GetAllAccounts>(); //1
            services.AddTransient<IPreviewMoneyOnAccount, PreviewMoneyOnAccount>(); //5
            services.AddTransient<IGetAllCategories, GetAllCategories>(); //7
            services.AddTransient<IGetCurrency, GetCurrency>(); //11
            services.AddTransient<IGetPaymentTypes, GetPaymentTypes>(); //16
            services.AddTransient<IGetPaymentForUser, GetPaymentForUser>(); //19
            services.AddTransient<IGetPaymentForOneAccount, GetPaymentForOneAccount>(); //20
            services.AddTransient<IGetUseCase, GetUseCase>(); //24
            services.AddTransient<IPreviewAllPriveledgesForuser, PreviewAllPriveledgesForuser>(); //27
            services.AddTransient<IGetTraceObjects, GetTraceObjects>(); //28

        }

        public static void AddCommandUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateNewUser, CreateNewUser>(); //2
            services.AddTransient<IActivateUser, ActivateUser>(); //3
            services.AddTransient<IAddOrRemoveMoneyToAccount, AddOrRemoveMoneyToAccount>(); //4
            services.AddTransient<INewPaymentCategory, NewPaymentCategory>(); //6
            services.AddTransient<IUpdatePaymentCategory, UpdatePaymentCategory>(); //8
            services.AddTransient<IPaymentCategoryDelete, PaymentCategoryDelete>(); //9
            services.AddTransient<IAddNewCurrency, AddNewCurrency>(); //10
            services.AddTransient<IUpdateCurrency, UpdateCurrency>(); //12
            services.AddTransient<IRemoveCurrency, RemoveCurrency>(); //13
            services.AddTransient<INewPaymentType, NewPaymentType>(); //14
            services.AddTransient<IUpdatePaymentType, UpdatePaymentType>(); //15
            services.AddTransient<IRemovePaymentType, RemovePaymentType>(); //17
            services.AddTransient<INewPayment, NewPayment>(); //18
            services.AddTransient<INewUseCase, NewUseCase>(); //21
            services.AddTransient<IUpdateUseCase, UpdateUseCase>(); //22
            services.AddTransient<IRemovePayment, RemovePayment>(); //23
            services.AddTransient<IAddUseCasePriviledge, AddUseCasePriviledge>(); //25
            services.AddTransient<IRemovePriviledgeUseCase, RemovePriviledgeUseCase>(); //26
            services.AddTransient<IAddSalary, AddSalary>(); //29

        }

        public static void AddValidators(this IServiceCollection services) 
        {
            services.AddTransient<CreateNewUserValidation>();
            services.AddTransient<ImageValidation>();
            services.AddTransient<UserActivationValidation>();
            services.AddTransient<AddOrRemoveMoneyValidator>();
            services.AddTransient<NewPaymentCategoryValidator>();
            services.AddTransient<UpdatePaymentCategoryValidator>();
            services.AddTransient<PaymentCategoryDeleteValidation>();
            services.AddTransient<AddNewCurrencyValidator>();
            services.AddTransient<UpdateCurrencyValidator>();
            services.AddTransient<RemoveCurrencyValidator>();
            services.AddTransient<NewPaymentTypeValidator>();
            services.AddTransient<UpdatePaymentTypeValidator>();
            services.AddTransient<RemovePaymentTypeValidator>();
            services.AddTransient<NewPaymentValidator>();
            services.AddTransient<NewUseCaseValidator>();
            services.AddTransient<UpdateUseCaseValidator>();
            services.AddTransient<RemovePaymentValidator>();
            services.AddTransient<AddUseCasePriviledgeValidator>();
            services.AddTransient<RemovePriviledgeUseCaseValidator>();
            services.AddTransient<EFLoggerValidator>();
            services.AddTransient<AddSalaryValidator>();


        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IAppActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonymusUser();
                }

                var actor = new JwtUser()
                {
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Identity").Value,
                    AllowedActions = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }

        public static void AddJwt(this IServiceCollection services)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = JwtConfig.JWTIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

    }
}
