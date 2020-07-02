# RichEdit for ASP.NET Core - How to integrate the control into a Blazor server application

## Requirements
- To use the RichEdit control in a Blazor application, you need to have a [Universal, DXperience, or ASP.NET subscription](https://www.devexpress.com/buy/net/).
- Versions of devexpress npm packages should be identical (their major and minor versions should be the same).
 
This example illustrates a possible way to integrate the client part of ASP.NET Core RichEdit into a Blazor server application. This can be done as follows:

1. Create a new Blazor application using recommendations from the following topic: [Get started with ASP.NET Core Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/get-started?view=aspnetcore-3.1&tabs=visual-studio).
2. Install necessary NPM packages.
 
The **devexpress-richedit** npm package references **devextreme** as [peerDependencies](https://docs.npmjs.com/files/package.json#peerdependencies). These peerDependencies packages should be installed manually. This allows developers to control the version of peerDependencies packages and guarantees that the package is installed once.
 
Install the RichEdit package with required peerDependencies:
 
* If the ```package.json``` file does not exist, create a new NPM configuration file by executing the following command: ```npm init -y```.
* Add the following dependencies to this file:
```
{
    ...
  "dependencies": {
    "devextreme": "<:xx.x.x:>",
    "devexpress-richedit": "<:xx.x.x:>"
  }
}
```
* Call ```npm i```.

You can find all libraries in the **node_modules** folder once installation is completed.
 
3. Create a rich edit bundle using recommendations from this help topic: [Create a RichEdit Bundle](https://docs.devexpress.com/AspNetCore/401721/office-inspired-controls/get-started/richedit-bundle).

```bash
cd node_modules/devexpress-richedit
npm i --save-dev
npm run build-custom
cd ../..
```
 
3. Copy rich edit scripts
* Copy the bundled script from ```node_modules/devexpress-richedit/dist/custom/dx.richedit.min.js``` to ```wwwroot/js```
* Copy bundled css resources from ```node_modules/devexpress-richedit/dist/custom/dx.richedit.css``` and icons from ```node_modules/devexpress-richedit/dist/custom/icons``` to ```wwwroot/css```
 
4. Register scripts in the <head> tag of ```Pages/_Host.cshtml```
 
```
<link href="css/dx.richedit.css" rel="stylesheet" />
<script src="js/dx.richedit.min.js"></script>
```
 
5. Create a JavaScript rich edit initializing function. For this, create a ```wwwroot/js/richedit-creator.js``` file and place the following content in it:
 
```javascript
function createRichEdit(documentAsBase64) {
    const options = DevExpress.RichEdit.createOptions();
    options.confirmOnLosingChanges.enabled = false;
    options.exportUrl = 'api/RichEdit/SaveDocument';
    options.width = '1400px';
    options.height = '900px';
    var richElement = document.getElementById("rich-container");
    window.richEdit = DevExpress.RichEdit.create(richElement, options);
    if (documentAsBase64)
        window.richEdit.openDocument(documentAsBase64, "DocumentName", DevExpress.RichEdit.DocumentFormat.Rtf);
}
```
 
Register the created script in the <head> tag of ```Pages/_Host.cshtml```
 
```
<script src="js/richedit-creator.js"></script>
```

6. Override the OnAfterRenderAsync method and call the function created in the previous step:

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
	if (firstRender)
	{
		var documentAsBase64 = "e1xydGYxXGRlZmYwe1xmb250dGJse1xmMCBDYWxpYnJpO319e1xjb2xvcnRibCA7XHJlZDB"
		+ "cZ3JlZW4wXGJsdWUyNTUgO1xyZWQyNTVcZ3JlZW4yNTVcYmx1ZTI1NSA7fXtcKlxkZWZjaHAgXGZzMjJ9e1xzdHl"
		+ "sZXNoZWV0IHtccWxcZnMyMiBOb3JtYWw7fXtcKlxjczFcZnMyMiBEZWZhdWx0IFBhcmFncmFwaCBGb250O317XCp"
		+ "cY3MyXGZzMjJcY2YxIEh5cGVybGluazt9e1wqXHRzM1x0c3Jvd2RcZnMyMlxxbFx0c3ZlcnRhbHRcdHNjZWxsY2J"
		+ "wYXQyXHRzY2VsbHBjdDBcY2x0eGxydGIgTm9ybWFsIFRhYmxlO319e1wqXGxpc3RvdmVycmlkZXRhYmxlfXtcaW5"
		+ "mb31cbm91aWNvbXBhdFxzcGx5dHduaW5lXGh0bWF1dHNwXGV4cHNocnRuXHNwbHRwZ3BhclxkZWZ0YWI3MjBcc2V"
		+ "jdGRcbWFyZ2xzeG4xNDQwXG1hcmdyc3huMTQ0MFxtYXJndHN4bjE0NDBcbWFyZ2JzeG4xNDQwXGhlYWRlcnk3MjB"
		+ "cZm9vdGVyeTcyMFxwZ3dzeG4xMjI0MFxwZ2hzeG4xNTg0MFxjb2xzMVxjb2xzeDcyMFxwYXJkXHBsYWluXHFse1x"
		+ "mczIyXGNmMFxjczEgRG9jdW1lbnQgdGV4dH1cZnMyMlxjZjBccGFyfQ==";

		await JSRuntime.InvokeVoidAsync("createRichEdit", documentAsBase64);
	}
}
```

<!-- default file list -->
*Files to look at*:

* [_Host.cshtml](./CS/Pages/_Host.cshtml)
* [Index.razor](./CS/Pages/Index.razor)
* [richedit-creator.js](./CS/wwwroot/js/richedit-creator.js)
* [RichEditController.cs](./CS/Controllers/RichEditController.cs)
* [package.json](./CS/package.json)
<!-- default file list end -->