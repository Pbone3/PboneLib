﻿using PboneLib.Utils;
using System;

namespace PboneLib.CustomLoading.Content.Conditions
{
    public static class TryToLoad
    {
        public static ITryToLoadCondition IsNotAbstract() => new IsNotAbstractCondition();
        public class IsNotAbstractCondition : ITryToLoadCondition
        {
            public bool Satisfies(Type type) => !type.IsAbstract;
        }

        public static ITryToLoadCondition DoesNotContainGenericParameters() => new DoesNotContainGenericParametersCondition();
        public class DoesNotContainGenericParametersCondition : ITryToLoadCondition
        {
            public bool Satisfies(Type type) => !type.ContainsGenericParameters;
        }

        public static ITryToLoadCondition HasZeroParameterConstructor() => new HasZeroParameterConstructorCondition();
        public class HasZeroParameterConstructorCondition : ITryToLoadCondition
        {
            public bool Satisfies(Type type) => type.GetConstructor(Array.Empty<Type>()) != null;
        }

        public static ITryToLoadCondition IsNotType<T>() => new IsNotTypeCondition<T>();
        public class IsNotTypeCondition<T> : ITryToLoadCondition
        {
            public bool Satisfies(Type type) => type != typeof(T);
        }

        public static ITryToLoadCondition ImplementsInterface<T>() => new ImplementsInterfaceCondition<T>();
        public class ImplementsInterfaceCondition<T> : ITryToLoadCondition
        {
            public bool Satisfies(Type type) => type.Implements<T>();
        }

        public static ITryToLoadCondition IsSubclassOf<T>() => new IsSubclassOfCondition<T>();
        public class IsSubclassOfCondition<T> : ITryToLoadCondition
        {
            public virtual bool Satisfies(Type type) => type.IsSubclassOf(typeof(T));
        }

        public static ITryToLoadCondition IsNotSubclassOf<T>() => new IsNotSubclassOfCondition<T>();
        public class IsNotSubclassOfCondition<T> : IsSubclassOfCondition<T>
        {
            public override bool Satisfies(Type type) => !base.Satisfies(type);
        }
    }
}
