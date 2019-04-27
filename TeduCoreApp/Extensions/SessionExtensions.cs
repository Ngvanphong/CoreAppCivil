﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeduCoreApp.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
        public static List<T> GetList<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(List<T>) :
                JsonConvert.DeserializeObject<List<T>>(value);
        }

        public static void SetList<T>(this ISession session, string key, List<T> value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
