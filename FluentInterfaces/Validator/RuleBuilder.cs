using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Validator
{
    public class RuleBuilder<T> where T: class
    {
        private readonly IDictionary<string, IList<IRule>> _rules = new Dictionary<string, IList<IRule>>();

        private string TypeName => typeof(T).ToString();
        
        public IEnumerable<IRule> Rules => _rules.Values.ToList().SelectMany(r => r);

        public static RuleBuilder<T> Instance => new RuleBuilder<T>();
        
        
        public RuleBuilder<T> IsNotNull()
        {
            if (!_rules.ContainsKey(TypeName))
            {
                _rules[TypeName] = new List<IRule>();
            }
            
            _rules[TypeName].Add(new NotNull<T>());
            return this;
        }

        public RuleBuilder<T> IsNotNull<TProperty>(Expression<Func<T, TProperty>> lambda)
        {
            var property = GetTPropertyName(lambda);
            
            if (!_rules.ContainsKey(property))
            {
                _rules[property] = new List<IRule>();
            }
            _rules[property].Add(new NotNull<T, TProperty>());
            return this;
        }
        
        protected string GetTPropertyName<TProperty>(Expression<Func<T, TProperty>> lambda)
        {
            var type = typeof(T);
            if (!(lambda.Body is MemberExpression member))
            {
                throw new ArgumentException($"Expression '{lambda}' refers to a method, not a property.");
            }
            
            if (!(member.Member is PropertyInfo propInfo))
            {
                throw new ArgumentException($"Expression '{lambda}' refers to a field, not a property.");
            }

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType!))
            {
                throw new ArgumentException($"Expression '{lambda}' refers to a property that is not from type {type}.");
            }
            
            return propInfo.Name;
        }
    }
}