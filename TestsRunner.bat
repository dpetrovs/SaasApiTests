del ".\HTMLReport\*.html"
".\packages\NUnit.ConsoleRunner.3.8.0\tools\nunit3-console.exe" ".\ApiTests\bin\Debug\ApiTests.dll" --result="ApiTests.xml;format=nunit3" --work=".\TestResults"

".\packages\ReportUnit.1.2.1\tools\ReportUnit.exe" ".\TestResults"