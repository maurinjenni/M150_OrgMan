﻿using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using OrgMan.Common.DynamicValidationService.Validators;
using OrgMan.Common.LinqExpressionService;
using OrgMan.DataModel;

namespace OrgMan.Common.DynamicValidationService
{
    public class DynamicValidationService<T> : IDynamicValidationService<T>
    {
        private IUnityContainer _unityContainer;

        public DynamicValidationService(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public bool Validate(T obj)
        {
            IDictionary<Type,Delegate> typeofProcessMap = new Dictionary<Type, Delegate>
            {
                {typeof(Person), new Action<Person>(p =>
                    {
                        Person person = (Person)(object)obj;
                        PersonValidator personValidator = new PersonValidator(new LinqExpressionService<Person>());
                        personValidator.Validate(person);
                    })
                },
                {typeof(Meeting), new Action<Meeting>(m =>
                    {
                        Meeting meeting = (Meeting)(object)obj;
                        MeetingValidator meetingValidator = new MeetingValidator(new LinqExpressionService<Meeting>());
                        meetingValidator.Validate(meeting);
                    })
                }
            };

            typeofProcessMap[typeof(T)].DynamicInvoke(obj);

            return true;
        }
    }
}

