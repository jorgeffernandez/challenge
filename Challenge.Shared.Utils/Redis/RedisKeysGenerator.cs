namespace MasMovil.Componentes.Citaciones.Shared.Utils.Redis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
   
    static class RedisKeysGenerator
    {
        public static string GenerateKey<T>(Expression<Func<T>> expression)
        {
            return GenerateKey(expression, string.Empty);
        }

        public static string GenerateKey<T>(Expression<Func<T>> expression, string applicationName)
        {
            var values = new List<string>();
            var call = expression.Body as MethodCallExpression;

            for (var i = 0; i < call.Arguments.Count; i++)
            {
                LambdaExpression lambda = Expression.Lambda(call.Arguments[i], expression.Parameters);
                Delegate d = lambda.Compile();
                values.Add($"p{i}{call.Arguments[i].Type.Name}={d.DynamicInvoke()}");
            }

            if (string.IsNullOrWhiteSpace(applicationName))
            {
                return $"{call.Method.Name}?{string.Join("&", values)}";
            }
            else
            {
                return $"{applicationName}:{call.Method.Name}?{string.Join("&", values)}";
            }
        }

        public static string GenerateKey(string methodName, Dictionary<string, object> parameters, string applicationName)
        {
            var keyValuePair = new List<string>();
            parameters.ToList().ForEach(x => keyValuePair.Add($"{x.Key}={x.Value}"));
            return $"{applicationName}:{methodName}?{string.Join("&", keyValuePair)}";
        }
    }
}
