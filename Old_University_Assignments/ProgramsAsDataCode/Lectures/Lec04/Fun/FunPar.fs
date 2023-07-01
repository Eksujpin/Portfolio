// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "FunPar.fsy"

 (* File Fun/FunPar.fsy 
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 "FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | AND
  | OR
  | LPAR
  | RPAR
  | EQ
  | NE
  | GT
  | LT
  | GE
  | LE
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_AND
    | TOKEN_OR
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Args
    | NONTERM_Expr
    | NONTERM_AtExpr
    | NONTERM_Vals
    | NONTERM_AppExpr
    | NONTERM_Const

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | AND  -> 1 
  | OR  -> 2 
  | LPAR  -> 3 
  | RPAR  -> 4 
  | EQ  -> 5 
  | NE  -> 6 
  | GT  -> 7 
  | LT  -> 8 
  | GE  -> 9 
  | LE  -> 10 
  | PLUS  -> 11 
  | MINUS  -> 12 
  | TIMES  -> 13 
  | DIV  -> 14 
  | MOD  -> 15 
  | ELSE  -> 16 
  | END  -> 17 
  | FALSE  -> 18 
  | IF  -> 19 
  | IN  -> 20 
  | LET  -> 21 
  | NOT  -> 22 
  | THEN  -> 23 
  | TRUE  -> 24 
  | CSTBOOL _ -> 25 
  | NAME _ -> 26 
  | CSTINT _ -> 27 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_AND 
  | 2 -> TOKEN_OR 
  | 3 -> TOKEN_LPAR 
  | 4 -> TOKEN_RPAR 
  | 5 -> TOKEN_EQ 
  | 6 -> TOKEN_NE 
  | 7 -> TOKEN_GT 
  | 8 -> TOKEN_LT 
  | 9 -> TOKEN_GE 
  | 10 -> TOKEN_LE 
  | 11 -> TOKEN_PLUS 
  | 12 -> TOKEN_MINUS 
  | 13 -> TOKEN_TIMES 
  | 14 -> TOKEN_DIV 
  | 15 -> TOKEN_MOD 
  | 16 -> TOKEN_ELSE 
  | 17 -> TOKEN_END 
  | 18 -> TOKEN_FALSE 
  | 19 -> TOKEN_IF 
  | 20 -> TOKEN_IN 
  | 21 -> TOKEN_LET 
  | 22 -> TOKEN_NOT 
  | 23 -> TOKEN_THEN 
  | 24 -> TOKEN_TRUE 
  | 25 -> TOKEN_CSTBOOL 
  | 26 -> TOKEN_NAME 
  | 27 -> TOKEN_CSTINT 
  | 30 -> TOKEN_end_of_input
  | 28 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Args 
    | 3 -> NONTERM_Args 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_Expr 
    | 19 -> NONTERM_Expr 
    | 20 -> NONTERM_Expr 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AtExpr 
    | 23 -> NONTERM_AtExpr 
    | 24 -> NONTERM_AtExpr 
    | 25 -> NONTERM_AtExpr 
    | 26 -> NONTERM_Vals 
    | 27 -> NONTERM_Vals 
    | 28 -> NONTERM_AppExpr 
    | 29 -> NONTERM_AppExpr 
    | 30 -> NONTERM_Const 
    | 31 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 30 
let _fsyacc_tagOfErrorTerminal = 28

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | AND  -> "AND" 
  | OR  -> "OR" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | AND  -> (null : System.Object) 
  | OR  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 2us; 65535us; 4us; 5us; 50us; 54us; 23us; 65535us; 0us; 2us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 34us; 16us; 35us; 17us; 36us; 18us; 37us; 19us; 38us; 20us; 39us; 21us; 40us; 22us; 41us; 23us; 42us; 24us; 43us; 25us; 44us; 26us; 45us; 27us; 46us; 28us; 51us; 29us; 52us; 30us; 55us; 31us; 56us; 32us; 58us; 33us; 26us; 65535us; 0us; 6us; 6us; 60us; 7us; 60us; 8us; 6us; 10us; 6us; 12us; 6us; 14us; 6us; 34us; 6us; 35us; 6us; 36us; 6us; 37us; 6us; 38us; 6us; 39us; 6us; 40us; 6us; 41us; 6us; 42us; 6us; 43us; 6us; 44us; 6us; 45us; 6us; 46us; 6us; 51us; 6us; 52us; 6us; 55us; 6us; 56us; 6us; 58us; 6us; 60us; 60us; 3us; 65535us; 6us; 62us; 7us; 63us; 60us; 61us; 23us; 65535us; 0us; 7us; 8us; 7us; 10us; 7us; 12us; 7us; 14us; 7us; 34us; 7us; 35us; 7us; 36us; 7us; 37us; 7us; 38us; 7us; 39us; 7us; 40us; 7us; 41us; 7us; 42us; 7us; 43us; 7us; 44us; 7us; 45us; 7us; 46us; 7us; 51us; 7us; 52us; 7us; 55us; 7us; 56us; 7us; 58us; 7us; 26us; 65535us; 0us; 47us; 6us; 47us; 7us; 47us; 8us; 47us; 10us; 47us; 12us; 47us; 14us; 47us; 34us; 47us; 35us; 47us; 36us; 47us; 37us; 47us; 38us; 47us; 39us; 47us; 40us; 47us; 41us; 47us; 42us; 47us; 43us; 47us; 44us; 47us; 45us; 47us; 46us; 47us; 51us; 47us; 52us; 47us; 55us; 47us; 56us; 47us; 58us; 47us; 60us; 47us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 6us; 30us; 57us; 61us; 85us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 14us; 1us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 1us; 1us; 2us; 2us; 3us; 1us; 3us; 2us; 4us; 28us; 2us; 5us; 29us; 1us; 6us; 14us; 6us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 1us; 6us; 14us; 6us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 1us; 6us; 14us; 6us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 1us; 7us; 14us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 14us; 8us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 14us; 8us; 9us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 14us; 8us; 9us; 10us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 14us; 8us; 9us; 10us; 11us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 14us; 8us; 9us; 10us; 11us; 12us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 15us; 16us; 17us; 18us; 19us; 20us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 16us; 17us; 18us; 19us; 20us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 17us; 18us; 19us; 20us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 18us; 19us; 20us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 19us; 20us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 20us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 23us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 23us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 24us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 24us; 14us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 25us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 18us; 1us; 19us; 1us; 20us; 1us; 21us; 1us; 22us; 2us; 23us; 24us; 2us; 23us; 24us; 1us; 23us; 1us; 23us; 1us; 23us; 1us; 24us; 1us; 24us; 1us; 24us; 1us; 24us; 1us; 25us; 1us; 25us; 2us; 26us; 27us; 1us; 27us; 1us; 28us; 1us; 29us; 1us; 30us; 1us; 31us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 19us; 21us; 24us; 26us; 29us; 32us; 34us; 49us; 51us; 66us; 68us; 83us; 85us; 100us; 115us; 130us; 145us; 160us; 175us; 190us; 205us; 220us; 235us; 250us; 265us; 280us; 295us; 310us; 325us; 340us; 355us; 370us; 372us; 374us; 376us; 378us; 380us; 382us; 384us; 386us; 388us; 390us; 392us; 394us; 396us; 398us; 400us; 403us; 406us; 408us; 410us; 412us; 414us; 416us; 418us; 420us; 422us; 424us; 427us; 429us; 431us; 433us; 435us; |]
let _fsyacc_action_rows = 66
let _fsyacc_actionTableElements = [|7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 0us; 49152us; 14us; 32768us; 0us; 3us; 1us; 45us; 2us; 46us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 0us; 16385us; 1us; 16386us; 26us; 4us; 0us; 16387us; 5us; 16388us; 3us; 58us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 5us; 16389us; 3us; 58us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 14us; 32768us; 1us; 45us; 2us; 46us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 23us; 10us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 14us; 32768us; 1us; 45us; 2us; 46us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 16us; 12us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 13us; 16390us; 1us; 45us; 2us; 46us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 5us; 16391us; 1us; 45us; 2us; 46us; 13us; 36us; 14us; 37us; 15us; 38us; 5us; 16392us; 1us; 45us; 2us; 46us; 13us; 36us; 14us; 37us; 15us; 38us; 5us; 16393us; 1us; 45us; 2us; 46us; 13us; 36us; 14us; 37us; 15us; 38us; 2us; 16394us; 1us; 45us; 2us; 46us; 2us; 16395us; 1us; 45us; 2us; 46us; 2us; 16396us; 1us; 45us; 2us; 46us; 11us; 16397us; 1us; 45us; 2us; 46us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 11us; 16398us; 1us; 45us; 2us; 46us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 11us; 16399us; 1us; 45us; 2us; 46us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 11us; 16400us; 1us; 45us; 2us; 46us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 11us; 16401us; 1us; 45us; 2us; 46us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 11us; 16402us; 1us; 45us; 2us; 46us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 13us; 16403us; 1us; 45us; 2us; 46us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 13us; 16404us; 1us; 45us; 2us; 46us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 14us; 32768us; 1us; 45us; 2us; 46us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 20us; 52us; 14us; 32768us; 1us; 45us; 2us; 46us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 17us; 53us; 14us; 32768us; 1us; 45us; 2us; 46us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 20us; 56us; 14us; 32768us; 1us; 45us; 2us; 46us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 17us; 57us; 14us; 32768us; 1us; 45us; 2us; 46us; 4us; 59us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 43us; 10us; 44us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 0us; 16405us; 0us; 16406us; 1us; 32768us; 26us; 50us; 2us; 32768us; 5us; 51us; 26us; 4us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 0us; 16407us; 1us; 32768us; 5us; 55us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 0us; 16408us; 7us; 32768us; 3us; 58us; 12us; 14us; 19us; 8us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 0us; 16409us; 5us; 16410us; 3us; 58us; 21us; 49us; 25us; 65us; 26us; 48us; 27us; 64us; 0us; 16411us; 0us; 16412us; 0us; 16413us; 0us; 16414us; 0us; 16415us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 8us; 9us; 24us; 25us; 27us; 28us; 34us; 40us; 48us; 63us; 71us; 86us; 94us; 108us; 116us; 122us; 128us; 134us; 137us; 140us; 143us; 155us; 167us; 179us; 191us; 203us; 215us; 229us; 243us; 258us; 273us; 288us; 303us; 318us; 326us; 334us; 342us; 350us; 358us; 366us; 374us; 382us; 390us; 398us; 406us; 414us; 422us; 423us; 424us; 426us; 429us; 437us; 445us; 446us; 448us; 456us; 464us; 465us; 473us; 474us; 480us; 481us; 482us; 483us; 484us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 2us; 1us; 1us; 6us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 1us; 1us; 7us; 8us; 3us; 1us; 2us; 2us; 2us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 4us; 4us; 4us; 4us; 4us; 5us; 5us; 6us; 6us; 7us; 7us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 16387us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16405us; 16406us; 65535us; 65535us; 65535us; 65535us; 16407us; 65535us; 65535us; 65535us; 16408us; 65535us; 16409us; 65535us; 16411us; 16412us; 16413us; 16414us; 16415us; |]
let _fsyacc_reductions ()  =    [| 
# 270 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 279 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "FunPar.fsy"
                                                               _1 
                   )
# 35 "FunPar.fsy"
                 : Absyn.expr));
# 290 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               [_1]     
                   )
# 39 "FunPar.fsy"
                 : 'Args));
# 301 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Args)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               _1 :: _2 
                   )
# 40 "FunPar.fsy"
                 : 'Args));
# 313 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               _1                     
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 324 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               _1                     
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 335 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 348 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 359 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 371 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 383 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 395 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 407 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 419 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 431 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 54 "FunPar.fsy"
                 : Absyn.expr));
# 443 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 55 "FunPar.fsy"
                 : Absyn.expr));
# 455 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 56 "FunPar.fsy"
                 : Absyn.expr));
# 467 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 57 "FunPar.fsy"
                 : Absyn.expr));
# 479 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 491 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                               If(_1, _3, CstB false) 
                   )
# 59 "FunPar.fsy"
                 : Absyn.expr));
# 503 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "FunPar.fsy"
                                                               If(_1, CstB true, _3)  
                   )
# 60 "FunPar.fsy"
                 : Absyn.expr));
# 515 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 64 "FunPar.fsy"
                                                               _1                     
                   )
# 64 "FunPar.fsy"
                 : Absyn.expr));
# 526 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 65 "FunPar.fsy"
                                                               Var _1                 
                   )
# 65 "FunPar.fsy"
                 : Absyn.expr));
# 537 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 66 "FunPar.fsy"
                 : Absyn.expr));
# 550 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Args)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _7 = (let data = parseState.GetInput(7) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 67 "FunPar.fsy"
                 : Absyn.expr));
# 564 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "FunPar.fsy"
                                                               _2                     
                   )
# 68 "FunPar.fsy"
                 : Absyn.expr));
# 575 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "FunPar.fsy"
                                                               [_1]     
                   )
# 72 "FunPar.fsy"
                 : 'Vals));
# 586 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Vals)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "FunPar.fsy"
                                                               _1 :: _2 
                   )
# 73 "FunPar.fsy"
                 : 'Vals));
# 598 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Vals)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 77 "FunPar.fsy"
                 : Absyn.expr));
# 610 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Vals)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 78 "FunPar.fsy"
                 : Absyn.expr));
# 622 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 82 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 82 "FunPar.fsy"
                 : Absyn.expr));
# 633 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : bool)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 83 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 83 "FunPar.fsy"
                 : Absyn.expr));
|]
# 645 "FunPar.fs"
let tables () : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 31;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
