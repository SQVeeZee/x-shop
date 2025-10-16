using System;
using System.Collections.Generic;

namespace Shop
{
    public readonly struct HandlerInfo<TBehaviour> : IEquatable<HandlerInfo<TBehaviour>> where TBehaviour : IProductBehaviour
    {
        public TBehaviour View { get; }
        public ProductConfig Config { get; }

        public HandlerInfo(TBehaviour behaviour, ProductConfig config)
        {
            View = behaviour;
            Config = config;
        }

        public bool Equals(HandlerInfo<TBehaviour> other) => EqualityComparer<TBehaviour>.Default.Equals(View, other.View) && Equals(Config, other.Config);

        public override bool Equals(object obj) => obj is HandlerInfo<TBehaviour> other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(View, Config);
    }
}