
#include <stdlib.h>
#include "ratc.h"

extern "C"
{
    extern char* ReturnHW( void );
};

int main()
_begin( main )

    printf( "%s\n", ReturnHW() );
    _return 0;

_end( main )
