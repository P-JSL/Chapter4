using System.Diagnostics;
using Microsoft.Extensions.Configuration;


// 프로젝트 폴더에 택스트 파일 생성
Trace.Listeners.Add(
    new TextWriterTraceListener(
        File.CreateText(
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),"log.txt"       
                )
            )
        )
    );
//텍스트 작성기는 버퍼링 되므로, 이 옵션을 설정해서
// 스기 작업 후 모든 수신기가 Flush()를 호출.
Trace.AutoFlush = true;

Debug.WriteLine("Debug says, I am watching");
Trace.WriteLine("Trace says, I am watching");



ConfigurationBuilder builder = new();
builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
IConfigurationRoot configuration = builder.Build();

TraceSwitch ts = new(
        displayName: "PacktSwitch",
        description: "This switch is set via a JSON config."
    );
configuration.GetSection("PacktSwitch").Bind(ts);

Trace.WriteLineIf(ts.TraceError, "Trace error");
Trace.WriteLineIf(ts.TraceWarning, "Trace Warning");
Trace.WriteLineIf(ts.TraceInfo, "Trace Info");
Trace.WriteLineIf(ts.TraceVerbose, "Trace Verbose");

