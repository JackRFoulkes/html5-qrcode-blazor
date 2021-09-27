# Html5-QRCode-Blazor

Html5-Qrcode-Blazor is a Blazor component library that allows you to add barcode scanning to your Blazor application. 
This library simply takes the [Html5-Qrcode](https://github.com/mebjas/html5-qrcode) library and wraps it in a reusable Blazor component.

## Installation

Use [Nuget](https://www.nuget.org/packages/html5-qrcode-blazor/1.0.0) to install.

## Usage

* Install NuGet Package.
* Add Scoped Instance Of BarcodeScannerService

    ```
    builder.Services.AddScoped<BarcodeScannerService>();
    ```

* Add Script Reference
    ```
    <script src="_content/html5-qrcode-blazor/js/html5-qrcode.min.js"></script>
    ```

* Add component
    ```
    <BarcodeScanner Fps="10" Qrbox="250" ContinuousScan="true" />
    ```

## Options
The following options are available that can be passed as parameters into the component.

* Fps (Int) : Camera FPS
* Qrbox (Int) : Size of scan area
* SingleScan (Bool) : If true, a single text box is displayed under the scanner to show the successful result.
* ContinuousScan (Bool) : If true, a table is shown with the results of all scans


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[Apache 2.0](https://www.apache.org/licenses/LICENSE-2.0)