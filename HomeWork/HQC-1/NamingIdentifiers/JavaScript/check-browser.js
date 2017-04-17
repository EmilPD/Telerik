function checkBrowser( event, arg) {
  var browserCodeName = window.navigator.appCodeName,

  if(browserCodeName === 'Mozilla') {
    alert('Yes');
  } else {
    alert('No');
  }
}