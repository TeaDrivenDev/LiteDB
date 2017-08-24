﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LiteDB
{
    public partial class BsonExpression
    {
        public static IEnumerable<BsonValue> LOWER(IEnumerable<BsonValue> values)
        {
            foreach (var value in values)
            {
                if (value.IsString)
                {
                    yield return value.AsString.ToLower();
                }
            }
        }

        public static IEnumerable<BsonValue> UPPER(IEnumerable<BsonValue> values)
        {
            foreach (var value in values)
            {
                if (value.IsString)
                {
                    yield return value.AsString.ToUpper();
                }
            }
        }

        public static IEnumerable<BsonValue> SUBSTRING(IEnumerable<BsonValue> values, IEnumerable<BsonValue> index, IEnumerable<BsonValue> length)
        {
            var idx = index?.Where(x => x.IsInt32).FirstOrDefault()?.AsInt32 ?? 0;
            var len = length?.Where(x => x.IsInt32).FirstOrDefault()?.AsInt32 ?? 0;

            foreach (var value in values)
            {
                if (value.IsString)
                {
                    yield return value.AsString.Substring(idx, len);
                }
            }
        }

        public static IEnumerable<BsonValue> LPAD(IEnumerable<BsonValue> values, IEnumerable<BsonValue> totalWidth, IEnumerable<BsonValue> paddingChar)
        {
            var width = totalWidth?.Where(x => x.IsInt32).FirstOrDefault()?.AsInt32 ?? 0;
            var pchar = paddingChar?.Where(x => x.IsString).FirstOrDefault()?.AsString.ToCharArray()[0] ?? '0';

            foreach (var value in values)
            {
                yield return value.AsString.PadLeft(width, pchar);
            }
        }

        public static IEnumerable<BsonValue> RPAD(IEnumerable<BsonValue> values, IEnumerable<BsonValue> totalWidth, IEnumerable<BsonValue> paddingChar)
        {
            var width = totalWidth?.Where(x => x.IsInt32).FirstOrDefault()?.AsInt32 ?? 0;
            var pchar = paddingChar?.Where(x => x.IsString).FirstOrDefault()?.AsString.ToCharArray()[0] ?? '0';

            foreach (var value in values)
            {
                yield return value.AsString.PadRight(width, pchar);
            }
        }
    }
}
