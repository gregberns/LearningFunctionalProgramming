using System;
using static LearnCsharpMaybe.Maybe<string>;
using static LearnCsharpMaybe.MaybeExtensions;

namespace LearnCsharpMaybe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //Usage
            //Construct
            Maybe<string> ma = Some("hello world");
            Maybe<string> none = None();
            
            //Map from string to int (length of string)
            Maybe<int> len = map(a => a.Length, ma); // Maybe<11> 

            //How to get the value out
            ma.Fold(a => a, () => "<empty>"); // "hello world"

            None().Fold(a => a, () => "<empty>"); // "<empty>"
            
            var strEx = from a in ma
                        select a + "!"; // Maybe<"hello world!">

            var concatd = from a in Some("hello")
                          from b in Some("world")
                          from c in Some("!")
                          select a + " " + b + c;

        }
    }

    public class Maybe<A>{
        private A a;
        private bool _isNone;

        private Maybe(bool isNone, A value){
            a = value;
            _isNone = isNone;
        }

        public static Maybe<A> None() =>
            new Maybe<A>(true, default(A));
        
        public static Maybe<A> Some(A value) =>
            new Maybe<A>(false, value);

        public B Fold<B>(Func<A, B> f, Func<B> none) =>
            _isNone ? none() : f(a); 

    }

    public static class MaybeExtensions {

        public static Maybe<B> map<A, B>(Func<A, B> f, Maybe<A> maybe) =>
            maybe.Fold<Maybe<B>>(a => Maybe<B>.Some(f(a)), () => Maybe<B>.None());

        //for linq
        public static Maybe<B> Select<A, B>(this Maybe<A> a, Func<A,B> f) =>
            map(f, a);
        
        public static Maybe<B> SelectMany<A, B>(this Maybe<A> k, Func<A, Maybe<B>> f) {
            return k.Fold(f, () => Maybe<B>.None());
        }
        
        public static Maybe<C> SelectMany<A, B, C>(this Maybe<A> k, Func<A, Maybe<B>> p, Func<A, B, C> f) {
           return SelectMany(k, a => Select(p(a), b => f(a, b)));
        }
    }
}
