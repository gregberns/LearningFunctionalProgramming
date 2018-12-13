module Project where

import Prelude
import Undefined
import Data.Foldable

{- Let's apply what we've learned from Higher Order Functions
   and Basic Syntax

-}

{- `Maybe` can be thought of two ways:
     * An Enum where each value can contain data
     * A Base class that contains two implementations

  `Just` contains the item returned from the database 
  `Nothing` represents the possibility of no value being found
-}
data Maybe a
  = Nothing
  | Just a

{- `showMaybe` allows us to print a `Maybe` as long
   as everything in the `Just` can be 'shown'
-}
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

-- Declare an implementation of `Account` for #123
account123 = 
  { acct: 123
  , balance: 100
  , transactions: [] 
  }

transactionsFor123 =
  [ { trans: 101, amount: 50 }
  , { trans: 102, amount: 75 }
  ]

{- `pure` is used to 'lift' a value into a 'context', in this
   case `Maybe`, but pure can be built to handle other contexts.

  > pure 5
  Just 5

  > pure "Hello"
  Just "Hello"
-}
pure :: forall a. a -> Maybe a
pure a = Just a

{- Mock out a response by returning the `account123` account

  Hint: use `pure`
  
  > fetchAccount 123
  Just ({ acct: 123, balance: 100, transactions: [] })
-}
fetchAccount :: Int -> Maybe Account
fetchAccount accountNumber =
  __

{- Mock out a response by returning `transactionsFor123`

  Hint: use `pure`

  > fetchTransactions 123
  Just ([{ amount: 50, trans: 101 },{ amount: 75, trans: 102 }])
-}
fetchTransactions :: Int -> Maybe (Array Transaction)
fetchTransactions accountNumber =
  __

{- Adjust an account's balance by subtracting a transaction's amount

  > applyTransaction account123 { trans: 101, amount: 50 }
  { acct: 123, balance: 50, transactions: [{ trans: 101, amount: 50 }] }

-}
applyTransaction :: Transaction -> Account -> Account
applyTransaction transaction account =
  account 
    { balance = account.balance - transaction.amount 
    , transactions = account.transactions <> [transaction]
    }

{- Apply several transactions to an account

  Hint: use `applyTransaction`, `flip`, and `foldl`
  Use `:t flip` to see its type signature

  Think: how could we change the `applyTransaction` to not use `flip`
  Or, is there an alternative to `foldl` that would solve the same problem

  > applyTransactions account123 transactionsFor123
  { acct: 123, balance: 125, transactions: [{ amount: 25, trans: 101 },{ amount: 50, trans: 102 }] }
-}
applyTransactions :: Account -> Array Transaction -> Account
applyTransactions account transactions =
  __

{- Tie actions together with `andThen`. Use it ensure one
  action is complete before subsequent computations are undertaken.

  Note: `andThen` is actually the `>>=` function (pronounced 'bind')
  We'll use this name to develop an intuition for how `>>=` works.

  Notice the similarities and differences with `map`.

  > Just 5 `andThen` (\i -> Just (show (i + 3)))
  Just ("8")

  > Nothing `andThen` (\i -> Just (show (i + 3)))
  Nothing
-}
andThen :: forall a b. Maybe a -> (a -> Maybe b) -> Maybe b
andThen (Just a) f = f a
andThen Nothing _ = Nothing


{- Fetch the account, `andThen` add 5 to the account balance

  Hint: use `pure` and record manipluation syntax to change the balance

  Notice how the function scope 'forces' the first argument 
  to be evaluated before the second can start to evaluate.

  > addTwentyFiveToAccountBalance 123
  Just ({ acct: 123, balance: 125, transactions: [] })
-}
addTwentyFiveToAccountBalance :: Int -> Maybe Account
addTwentyFiveToAccountBalance accountNumber =
  (fetchAccount accountNumber) `andThen` (\account ->
  __
  )

{- Fetch an account, then its transactions, then apply the 
   transactions to the account.

  Hint: use `pure` and `applyTransactions`

  > processAccount 123
  Just ({ acct: 123, balance: -25, transactions: [{ amount: 50, trans: 101 },{ amount: 75, trans: 102 }] })
-}
processAccount :: Int -> Maybe Account
processAccount accountNumber =
  __ `andThen` (\account ->
  (fetchTransactions accountNumber) `andThen` (\transactions ->
  __
  ))
