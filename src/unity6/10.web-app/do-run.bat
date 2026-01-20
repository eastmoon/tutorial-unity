@rem
@rem Copyright 2020 the original author jacky.eastmoon
@rem All commad module need 3 method :
@rem [command]        : Command script
@rem [command]-args   : Command script options setting function
@rem [command]-help   : Command description
@rem Basically, CLI will not use "--options" to execute function, "--help, -h" is an exception.
@rem But, if need exception, it will need to thinking is common or individual, and need to change BREADCRUMB variable in [command]-args function.
@rem NOTE, batch call [command]-args it could call correct one or call [command] and "-args" is parameter.
@rem

@rem ------------------- batch setting -------------------
@rem setting batch file
@rem ref : https://www.tutorialspoint.com/batch_script/batch_script_if_else_statement.htm
@rem ref : https://poychang.github.io/note-batch/

@echo off
setlocal
setlocal enabledelayedexpansion

@rem ------------------- declare CLI file variable -------------------
set CLI_FILENAME=%~n0

@rem ------------------- execute script -------------------

set PROJECT_PATH=%cd%\app\Build\WebGL
set CONFIG_PATH=%cd%\conf\nginx
IF EXIST "%PROJECT_PATH%" (
    docker run -d --rm ^
        -v %PROJECT_PATH%:/usr/share/nginx/html ^
        -v %CONFIG_PATH%:/etc/nginx/conf.d ^
        -p 80:80 ^
        nginx
) else (
    echo "%PROJECT_PATH%" not find.
)
