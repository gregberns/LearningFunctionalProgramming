module Undefined where

foreign import undefined :: forall anything. anything 

__ = undefined
_0_ :: Int
_0_ = undefined
