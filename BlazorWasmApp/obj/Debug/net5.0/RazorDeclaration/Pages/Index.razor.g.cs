// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorWasmApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\_Imports.razor"
using BlazorWasmApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\_Imports.razor"
using BlazorWasmApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\Pages\Index.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\Pages\Index.razor"
using System.IO.Compression;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\Pages\Index.razor"
using System.Diagnostics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\Pages\Index.razor"
using System.Text;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 36 "C:\Users\Cecilia\source\repos\blazor-zipping\BlazorWasmApp\Pages\Index.razor"
       
    private static IBrowserFile originalFile;
    private bool isLoading;
    private bool hasUploaded;
    private static bool zipping;
    private static Stopwatch timer = new();
    

    void Upload(InputFileChangeEventArgs e)
    {
        isLoading = true;
        hasUploaded = false;
        zipping = false;
        timer.Reset();

        originalFile = e.GetMultipleFiles(1).FirstOrDefault();
        isLoading = false;
        hasUploaded = true;
    }

    [JSInvokable]
    public static async Task<ZipFileResult> BeginZipFile()
    {
        zipping = true;
        var stream = await Zipit();
        return new ZipFileResult { FileName = "test.zip", ContentType = "application/octet-stream", FileBytes = stream.ToArray() };
    }

    public class ZipFileResult
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] FileBytes { get; set; }
    }

    private static async Task<MemoryStream> Zipit()
    {
        await using var zipFileMemoryStream = new MemoryStream();
        using var archive = new ZipArchive(zipFileMemoryStream, ZipArchiveMode.Create, leaveOpen: true, Encoding.UTF8);
        var entry = archive.CreateEntry(originalFile.Name, CompressionLevel.Optimal);
        await using var entryStream = entry.Open();
        await originalFile.OpenReadStream(74400320 ).CopyToAsync(entryStream);
        await zipFileMemoryStream.CopyToAsync(entryStream);
        return zipFileMemoryStream;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
