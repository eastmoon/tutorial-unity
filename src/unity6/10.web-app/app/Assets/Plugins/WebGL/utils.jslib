mergeInto(LibraryManager.library, {
  Hello: function () {
    window.alert("Hello, world!!!!");
  },
  Resolution: function () {
    // Resolution JSON object
    var dataObj = {
        width: window.innerWidth,
        height: window.innerHeight
    };
    // Convert the JavaScript object to a JSON string
    var jsonString = JSON.stringify(dataObj);
    // Return JSON string
    return jsonString;
  },
  SetFullWidnsow: function () {
    // Setting canvas element size
    document.getElementById('unity-canvas').style.width='100vw';
    document.getElementById('unity-canvas').style.height='100vh';
    // Close unity element
    document.getElementById('unity-warning').style.display = "none";
    document.getElementById('unity-footer').style.display = "none";
    // close body scrollbar
    document.body.style.overflow = "hidden";
  },
});
