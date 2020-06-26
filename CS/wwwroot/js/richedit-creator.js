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