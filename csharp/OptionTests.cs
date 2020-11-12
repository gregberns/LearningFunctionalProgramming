using System;
using Xunit;
using static Functional.F;
using Functional;

namespace Functional
{
    public static partial class OptionExt
    {
        // Implement Filter, Map, Bind

        // Filter :: Option<T> -> (T -> bool) -> Option<T>
        public static Option<T> Filter<T>(this Option<T> input, Func<T, bool> f) =>
            // This will help you start out
            // 1) Remove this line
            None<T>()
            // 2) Uncomment the following and Fill in the blanks
            // input.Match(
            //     Some: i => ______,
            //     None: () => ______
            // )
            ;

        // Map :: Option<A> -> (A -> B) -> Option<B>

        // Bind :: Option<A> -> (A -> Option<B>) -> Option<B>

    }
}

namespace csharp
{
    public class OptionFilterTests
    {
        [Fact]
        public void Equality()
        {
            Assert.Equal(Some(1), Some(1));
            Assert.Equal(Some(Some(1)), Some(Some(1)));
            Assert.Equal(None<int>(), None<int>());

            Assert.NotEqual(Some(1), None<int>());
            Assert.NotEqual(Some(1), Some(2));
            Assert.NotEqual(Some(Some(1)), Some(Some(2)));
            Assert.NotEqual(Some(Some(1)), Some(None<int>()));

        }
        [Fact]
        public void Filter_Evens()
        {
            var result_evens = Some(2)
                            // Uncomment the following once you've implemented Filter
                            // .Filter(i => i % 2 == 0)
                            ;
            // Assert.Equal(Some(2), result_evens);
        }
        [Fact]
        public void Filter_Odds()
        {
            var result_odds = Some(2)
                            // Uncomment the following once you've implemented Filter
                            // .Filter(i => i % 2 == 0)
                            ;
            // Assert.Equal(None<int>(), result_odds);
        }
        [Fact]
        public void Filter_None()
        {
            var always_true = None<string>()
                            // Uncomment the following once you've implemented Filter
                            // .Filter(i => true)
                            ;
            // Assert.Equal(None<string>(), always_true);

            var always_false = None<string>()
                            // Uncomment the following once you've implemented Filter
                            // .Filter(i => false)
                            ;
            // Assert.Equal(None<string>(), always_false);
        }
    }
    public class OptionMapTests
    {
        [Fact]
        public void Map_Int_to_String()
        {
            var result = Some(1)
                            // Uncomment the following once you've implemented Map
                            // .Map(i => $"Value: {i}")
                            ;
            // Assert.Equal(Some("Value: 1"), result);
        }
        [Fact]
        public void Map_None()
        {
            var result = None<string>()
                            // Uncomment the following once you've implemented Map
                            // .Map(i => $"Value: {i}")
                            ;
            // Assert.Equal(None<string>(), result);
        }
        [Fact]
        public void Map_Nested()
        {
            var result_even = Some(2)
                            // Uncomment the following once you've implemented Map
                            // .Map(i => i % 2 == 0 ? Some(i.ToString()) : None<string>())
                            ;
            // Assert.Equal(Some(Some("2")), result_even);

            var result_odd = Some(1)
                            // Uncomment the following once you've implemented Map
                            // .Map(i => i % 2 == 0 ? Some(i.ToString()) : None<string>())
                            ;
            // Assert.Equal(Some(None<string>()), result_odd);
        }
    }

    public class OptionBindTests
    {
        [Fact]
        public void Bind_Int_to_String()
        {
            var result = Some(1)
                            // Uncomment the following once you've implemented Map
                            // .Bind(i => Some($"Value: {i}"))
                            ;
            // Assert.Equal(Some("Value: 1"), result);
        }
        [Fact]
        public void Bind_None()
        {
            var result = None<string>()
                            // Uncomment the following once you've implemented Map
                            // .Bind(i => Some($"Value: {i}"))
                            ;
            // Assert.Equal(None<string>(), result);
        }
        [Fact]
        public void Bind_Nested()
        {
            var result_even = Some(2)
                            // Uncomment the following once you've implemented Map
                            // .Bind(i => i % 2 == 0 ? Some(i.ToString()) : None<string>())
                            ;
            // Assert.Equal(Some("2"), result_even);

            var result_odd = Some(1)
                            // Uncomment the following once you've implemented Map
                            // .Bind(i => i % 2 == 0 ? Some(i.ToString()) : None<string>())
                            ;
            // Assert.Equal(None<string>(), result_odd);
        }
    }
}