module InProgress where

import Prelude

--filter??
-- f a =  a > 5
-- --validation
-- Just 10  -> Just 10
-- Just 3   -> Nothing
-- Nothing  -> Nothing


-- Now lets use the ideas we just 

-- data Maybe a = Nothing | Just a

-- some = Just "Hello"
-- none = Nothing

-- appendString :: String -> String
-- appendString baseString = baseString <> " World!"

-- surroundWith start end base = start <> base <> end

-- -- Go to database and return AccountName
-- acctName = Just "Jon Doe"
-- surroundWithBrackets str = surroundWith "[" "]" str


-- addBrackets maybeStr = map surroundWithBrackets maybeStr


-- changeInnerValue :: (String -> Int) -> Maybe String -> Maybe Int
-- changeInnerValue stringToIntFunc (Just string) = Just (stringToIntFunc string) --pass the inner string value to the function
-- changeInnerValue stringToIntFunc (Nothing) = Nothing

-- -- Or...

-- map :: forall a b. (a -> b) -> Maybe a -> Maybe b
-- map f (Just a) = Just (f a)
-- map f Nothing = Nothing

-- Whats the difference between `changeInnerValue` and `map`





--find account in accounts (filter)
--fn accepts acct and applies a transaction (map or reduce)
