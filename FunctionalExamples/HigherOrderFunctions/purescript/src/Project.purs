module Project where

import Prelude
import Undefined
import Data.Foldable

--get pretend data from database... an Account and set of Accounts

-- `Maybe` can be thought of two ways:
--   * An Enum where each value can contain data
--   * A Base class that contains two implementations
data Maybe a =
  -- `Just` contains the item returned from the database 
  Just a
  -- `Nothing` represents the possibility of no value being found
  | Nothing
instance showMaybe :: Show a => Show (Maybe a) where
  show (Just a) = "Just (" <> show a <> ")"
  show Nothing = "Nothing"


-- `Account` is a 'record', like a class with only properties
type Account =
  { acct :: Int
  , balance :: Int
  , transactions :: Array Transaction
  }

type Transaction =
  { trans :: Int
  , amount :: Int
  }

account123 = 
  { acct: 123
  , balance: 100
  , transactions: [] 
  }

transactionsFor123 =
  [ { trans: 101, amount: 50 }
  , { trans: 102, amount: 75 }
  ]

fetchAccount :: Int -> Maybe Account
fetchAccount accountNumber =
  -- let query = "SELECT * FROM tbl WHERE AccountNumber = " <> show id
  -- hard code the return value for now
  Just account123

fetchTransactions :: Int -> Maybe (Array Transaction)
fetchTransactions accountNumber =
  Just transactionsFor123

{- Adjust an account's balance 

  > applyTransaction account123 { trans: 101, amount: 50 }
  { acct: 123, balance: 50, transactions: [{ trans: 101, amount: 50 }] }

-}
applyTransaction :: Account -> Transaction -> Account
applyTransaction account transaction =
  account 
    { balance = account.balance - transaction.amount 
    , transactions = account.transactions <> [transaction]
    }


{- Apply several transactions to an account

  > applyTransactions account123 transactionsFor123
  { acct: 123, balance: 125, transactions: [{ amount: 25, trans: 101 },{ amount: 50, trans: 102 }] }
-}
applyTransactions :: Account -> Array Transaction -> Account
applyTransactions account transactions =
  foldl applyTransaction account transactions


{- Tie actions together with `andThen`
   
  > Just 5 `andThen` (\i -> Just (show (i + 3)))
  Just ("8")

  > Nothing `andThen` (\i -> Just (show (i + 3)))
  Nothing

-}
andThen :: forall a b. Maybe a -> (a -> Maybe b) -> Maybe b
andThen (Just a) f = f a
andThen Nothing _ = Nothing

pure :: forall a. a -> Maybe a
pure a = Just a

{- Fetch an account and its transactions, then apply

  > processAccount 123
  Just ({ acct: 123, balance: -25, transactions: [{ amount: 50, trans: 101 },{ amount: 75, trans: 102 }] })

-}
processAccount :: Int -> Maybe Account
processAccount accountNumber =
  andThen (fetchAccount accountNumber) (\account ->
  andThen (fetchTransactions accountNumber) (\transactions ->
  pure (applyTransactions account transactions)
  ))




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
