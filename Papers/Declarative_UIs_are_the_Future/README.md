# Declarative UIs are the Future — And the Future is Comonadic!

by Phil Freeman

Abstract
There are many techniques for the declarative specification
of user interfaces, but it is not clear how to study their similarities
and differences. The category-theoretic notion of a
comonad captures some essential aspects of these specifi-
cation techniques. The approach presented here generalizes
several known techniques, but perhaps more interestingly, it
also generates several new comonads as we search for ways
to represent existing user interfaces.

Keywords: Haskell, functional programming, specification, laziness, user interfaces, comonads

http://functorial.com/the-future-is-comonadic/main.pdf

# Comonads for user interfaces

by Arthur  Xavier

https://www.dropbox.com/s/7fa051n5dmub9fa/ComonadsForUIs.pdf

User  interfaces  (UIs)  are  difficult  to  implement.  They  are  important  parts  of  real-worldapplications,  which,  traditionally,  have  been  developed  in  a  heavily  imperative  style.Recently,  however,  many  techniques  for  the  building  of  declarative  user  interfaces  havecome  into  play.  These  techniques,  for  the  most  part,  define  different  architectural  stylesor  paradigms  for  implementing  and  organizing  user  interfaces  in  applications.  Inspiredby  this,  Freeman  [2016b]  makes  use  of  category-theoretical  structures  calledcomonadsinorder  to  develop  a  pure  functional  model  that  summarizes  and  abstracts  many  differentuser  interface  paradigms  and  all  their  subtleties,  whereby  each  different  UI  paradigm  (orarchitecture)  corresponds  to  a  different  comonad.
