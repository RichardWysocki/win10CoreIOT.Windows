// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using Services.Library;
using StructureMap;
using win10Core.Business;
using win10Core.Business.DataAccess;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine;
using win10Core.Business.Engine.Interface;
using win10Core.Business.Model;

namespace Services.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            //var container = new Container(_ =>
            //{
            //    _.Scan(x =>
            //    {
            //        x.TheCallingAssembly();
            //        x.WithDefaultConventions();
            //    });
            //});

            var registry = new Registry();
            registry.IncludeRegistry<PurpleRegistry>();
            // build a container
            var container = new Container(registry);

            return container;
        }

        public class PurpleRegistry : Registry
        {
            public PurpleRegistry()
            {
                For<IDBContext>().Use<DBContext>();
                For<IServiceSetting>().Use<ServiceSetting>();
                For<IServiceLayer>().Use<ServiceLayer>();
                For<ILogInfoDataAccess>().Use<LogInfoDataAccess>();
                For<ILogErrorDataAccess>().Use<LogErrorDataAccess>();
                For<IFamilyDataAccess>().Use<FamilyDataAccess>();
                For<IParentDataAccess>().Use<ParentDataAccess>();
                For<IKidDataAccess>().Use<KidDataAccess>();
                For<IGiftDataAccess>().Use<GiftDataAccess>();

                For<ILogEngine>().Use<LogEngine>();
                For<IKidEngine>().Use<KidEngine>();
                For<IParentEngine>().Use<ParentEngine>();
                For<IGiftEngine>().Use<GiftEngine>();

                For<IEmailEngine>().Use(new EmailEngine( new EmailConfiguration
                    {
                        SMTPServer = ConfigHelper.GetSetting("SMTPServer"),
                        SmtpServerUserName = ConfigHelper.GetSetting("AuthUserName"),
                        SmtpServerPassword = ConfigHelper.GetSetting("AuthPassword")
                    }
                    , new LogErrorDataAccess(new DBContext())));

                For<IEmailConfiguration>().Use<EmailConfiguration>();

                //For<ISubject>().Use<Subject>();
            }
        }
    }
}