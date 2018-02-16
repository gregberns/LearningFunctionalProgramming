# Transformations - Shape Changes in FP


Map
Filter
Reduce/Fold

Zip


Identity

a -> a


Map

[a1, a2, ...] -> (a -> b) -> [b1, b2, ...]


Filter

[a1, a2, a3, ...] -> (a -> bool) -> [a1, a3, ...]


Reduce/Fold

[a1, a2, a3, ...] -> a0 -> (a0 -> ) -> a

Apply

[a1, a2, a3, ...] -> f(a) -> a



Zip

[a1, a2, a3, ...]
                  -> (a -> b -> (a,b)) -> [(a1, b1), (a2, b2), (a3, b3), ...]
[b1, b2, b3, ...]

