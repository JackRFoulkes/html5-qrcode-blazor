var dotNetRef;
var html5QrcodeScanner;
var continuous;
var singlescan;

function onScanSuccess(decodedText, decodedResult) {

	if (singlescan) {
		html5QrcodeScanner.clear();
    }
	dotNetRef.invokeMethodAsync('SuccessfulScan', decodedText.toString());
}

export function CreateBarcodeScanner(options, dotNetObject) {
	html5QrcodeScanner = new Html5QrcodeScanner(
		"reader", { fps: options.fps, qrbox: options.qrbox }, /* verbose= */ false);
	html5QrcodeScanner.render(onScanSuccess);
	dotNetRef = dotNetObject;
	continuous = options.continuous;
	singlescan = options.singlescan;
}