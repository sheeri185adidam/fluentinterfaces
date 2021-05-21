using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Validator
{
    public class RuleBuilder<T>
    {
        private readonly IDictionary<string, IList<IRule<T>>> _rules = new Dictionary<string, IList<IRule<T>>>();

        private string TypeName => typeof(T).ToString();
        
        public IEnumerable<IRule<T>> Rules => _rules.Values.ToList().SelectMany(r => r);

        public static RuleBuilder<T> Instance => new RuleBuilder<T>();
        
        
        public virtual RuleBuilder<T> IsNotNull()
        {
            if (!_rules.ContainsKey(TypeName))
            {
                _rules[TypeName] = new List<IRule<T>>();
            }
            
            _rules[TypeName].Add(new NotNull<T>());
            return this;
        }

        public virtual RuleBuilder<T> IsNotNull<TProperty>(Expression<Func<T, TProperty>> lambda)
        {
            var property = GetTPropertyName(lambda);
            
            if (!_rules.ContainsKey(property))
            {
                _rules[property] = new List<IRule<T>>();
            }
            _rules[property].Add(new NotNull<T, TProperty>(property));
            return this;
        }

        public virtual RuleBuilder<T> IsEqualTo(T other)
        {
            if (!_rules.ContainsKey(TypeName))
            {
                _rules[TypeName] = new List<IRule<T>>();
            }
            
            _rules[TypeName].Add(new EqualTo<T>(other));
            return this;
        }
        
        public virtual RuleBuilder<T> IsEqualTo<TProperty>(Expression<Func<T, TProperty>> lambda, TProperty other)
        {
            var property = GetTPropertyName(lambda);
            
            if (!_rules.ContainsKey(property))
            {
                _rules[property] = new List<IRule<T>>();
            }
            
            _rules[property].Add(new EqualTo<T, TProperty>(property, other));
            return this;
        }
        
        protected virtual string GetTPropertyName<TProperty>(Expression<Func<T, TProperty>> lambda)
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