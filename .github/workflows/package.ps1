mkdir .dist | Out-Null

Move-Item ".\${env:_RELEASE_NAME}\bin\${env:_RELEASE_CONFIGURATION}\*.nupkg" -Destination ".\.dist\"
Move-Item ".\${env:_RELEASE_NAME}\bin\${env:_RELEASE_CONFIGURATION}\*.snupkg" -Destination ".\.dist\"
