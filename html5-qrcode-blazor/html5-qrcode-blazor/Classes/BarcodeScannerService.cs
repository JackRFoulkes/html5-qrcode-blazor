using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace html5_qrcode_blazor.Classes
{
    public class BarcodeScannerService : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> barcodeScanner;

        #region Properties
        public string LastScannedItem { get; set; }
        #endregion

        #region Events
        public event EventHandler OnSuccessfulScan;
        #endregion

        public BarcodeScannerService(IJSRuntime jsRuntime)
        {
            barcodeScanner = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/html5-qrcode-blazor/js/html5-qrcode-barcodescanner.js").AsTask());
        }

        public async Task CreateBarcodeScanner(int fps, int qrbox, bool continuous, bool singlescan)
        {
            var dotNetReference = DotNetObjectReference.Create(this);
            var module = await barcodeScanner.Value;
            await module.InvokeVoidAsync("CreateBarcodeScanner",
                    new
                    {
                        fps,
                        qrbox,
                        continuous,
                        singlescan
                    }, dotNetReference);
        }

        [JSInvokable("SuccessfulScan")]
        public void SuccessfulScan(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                LastScannedItem = text;
                OnSuccessfulScan?.Invoke(this, EventArgs.Empty);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (barcodeScanner.IsValueCreated)
            {
                var module = await barcodeScanner.Value;
                await module.DisposeAsync();
            }
        }
    }
}
