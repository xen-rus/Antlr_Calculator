grammar CalcGrammer;

start : argumentException | expr | <EOF> ;



expr : '-' expr     # UMS
   | '(' expr')'   # PARGRP
   | expr mulop expr # MULDGRP
   | expr addop expr # ADDRGRP
   | NUMBER      # NUM
   ;

argumentException
    :   
        |expr'('
        |')'expr
        |expr expr
    ;


addop : '+' | '-' ;
mulop : '*' | '/' ;

NUMBER : ('0' .. '9') + ('.' ('0' .. '9') +)?  | ('0' .. '9') + (',' ('0' .. '9') +)?;

WS : [ \r\n\t ;] + -> skip ;

