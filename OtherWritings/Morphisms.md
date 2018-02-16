# Morphisms

http://math.ucr.edu/home/baez/rosetta.pdf


Hilbert Spaces - describe Physical systems
Where morphisms are linear operators, used to describe physical processes (operators between Hilbert spaces)

As we shall see, Hilb and nCob share many structural features. Moreover, both are very different from
the more familiar category Set, whose objects are sets and whose morphisms are functions.

Definition 1 A category C consists of:
• a collection of objects, where if X is an object of C we write X ∈ C, and
• for every pair of objects (X, Y), a set hom(X, Y) of morphisms from X to Y. We call this set hom(X, Y) a
homset. If f ∈ hom(X, Y), then we write f : X → Y.
such that:
• for every object X there is an identity morphism 1X: X → X;
• morphisms are composable: given f : X → Y and g: Y → Z, there is a composite morphism g f : X → Z;
sometimes also written g ◦ f .
• an identity morphism is both a left and a right unit for composition: if f : X → Y, then f 1X = f = 1Y f ;
and
• composition is associative: (hg)f = h(g f) whenever either side is well-defined.
Definition 2 We say a morphism f : X → Y is an isomorphism if it has an inverse— that is, there exists another
morphism g: Y → X such that g f = 1X and f g = 1Y .

A category is the simplest framework where we can talk about systems (objects) and processes (morphisms).



