module HofInPractice where

import Prelude
import Data.Array
import Undefined
import Data.Foldable (foldl)



type Account =
  { number :: Int
  , balance :: Int
  }

accounts = 
  [{ number: 123
  ,  balance: 100
  },
  { number: 234
  , balance: 150
  },
  { number: 345
  , balance: 200
  }]

-- Use `filter` to find an account
-- > findAccount 123 accounts
-- [{ balance: 100, number: 123 }] 
findAccount :: Int -> Array Account -> Array Account
findAccount acctNumber accts =  filter (\acct -> acct.number == __) accts

-- Find account with balance over an amount
-- > findBalanceGreaterThan 125 accounts
-- [{ balance: 150, number: 234 }]
findBalanceGreaterThan :: Int -> Array Account -> Array Account
findBalanceGreaterThan balance accts = filter __ accts

--  Get list of balances
-- > retrieveBalances accounts
-- [100,150]
retrieveBalances :: Array Account -> Array Int
retrieveBalances accts = map __ accts

-- Change balances on all accounts
-- > modifyBalanceBy 100 accounts
-- [{ balance: 200, number: 123 },{ balance: 250, number: 234 }]
modifyBalanceBy :: Int -> Array Account -> Array Account
modifyBalanceBy amount accts = map (\acct -> acct { balance = _0_} ) accts


-- Add all balances together
-- > aggregateBalances accounts
-- 250
aggregateBalances :: Array Account -> Int
aggregateBalances accts = foldl (\accumulator acct -> __) 0 accts 
