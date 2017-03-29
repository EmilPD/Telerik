function solve() {
    return function(selector, defaultLeft, defaultRight) {
        var root = document.querySelector(selector);
        var container = document.createElement("div");
        container.className = "column-container";
        var leftColumn = document.createElement("div");
        leftColumn.className = "column";
        var rightColumn = leftColumn.cloneNode(true);
        var selectDivLeft = document.createElement("div");
        selectDivLeft.className = "select";
        var selectDivRight = selectDivLeft.cloneNode(true);
        var radioButtonLeft = document.createElement("input");
        radioButtonLeft.type = "radio";
        radioButtonLeft.name = "column-select";
        radioButtonLeft.id = "select-left-column";
        radioButtonLeft.checked = true;
        var radioButtonRight = document.createElement("input");
        radioButtonRight.type = "radio";
        radioButtonRight.name = "column-select";
        radioButtonRight.id = "select-right-column";
        var labelLeft = document.createElement("label");
        labelLeft.htmlFor = "select-left-column";
        labelLeft.innerHTML = "Add here";
        var labelRight = document.createElement("label");
        labelRight.htmlFor = "select-right-column";
        labelRight.innerHTML = "Add here";
        var list = document.createElement("ol");
 
        selectDivLeft.appendChild(radioButtonLeft);
        selectDivLeft.appendChild(labelLeft);
        selectDivRight.appendChild(radioButtonRight);
        selectDivRight.appendChild(labelRight);
        leftColumn.appendChild(selectDivLeft);
        leftColumn.appendChild(list);
        rightColumn.appendChild(selectDivRight);
        rightColumn.appendChild(list.cloneNode(true));
        container.appendChild(leftColumn);
        container.appendChild(rightColumn);
        var input = document.createElement("input");
        input.size = 40;
        input.autofocus = true;
        var button = document.createElement("button");
        button.innerHTML = "Add";
        root.appendChild(container);
        root.appendChild(input);
        root.appendChild(button);
        var frag = document.createDocumentFragment();
        var li = document.createElement("li");
        li.className = "entry";
        var image = document.createElement("img");
        image.className = "delete";
        image.src = "imgs/Remove-icon.png";
 
        if (!String.prototype.trim) {
            String.prototype.trim = function() {
                return this.replace(/^\s+|\s+$/g, '');
            };
        }
 
        function generateListValues(arr) {
            for (var index = 0; index < arr.length; index += 1) {
                var currentLi = li.cloneNode(true);
                var currentImage = image.cloneNode(true);
                var currentText = document.createTextNode(arr[index]);
                currentLi.appendChild(currentImage);
                currentLi.appendChild(currentText);
                frag.appendChild(currentLi);
            }
 
            return frag;
        }
 
        function addItem(text) {
            if (!text || text.trim().length === 0) {
                return;
            }
 
            var newLi = li.cloneNode(true);
            var newImage = image.cloneNode(true);
            var newText = document.createTextNode(text.trim());
            newLi.appendChild(newImage);
            newLi.appendChild(newText);
            if (radioButtonLeft.checked) {
                leftColumn.lastChild.appendChild(newLi);
            } else {
                rightColumn.lastChild.appendChild(newLi);
            }
 
            input.value = "";
        }
 
        if (defaultLeft) {
            var leftFrag = generateListValues(defaultLeft);
            leftColumn.lastElementChild.appendChild(leftFrag);
        }
 
        if (defaultRight) {
            var rightFrag = generateListValues(defaultRight);
            rightColumn.lastElementChild.appendChild(rightFrag);
        }
 
        button.addEventListener("click", function() {
            var inputValue = input.value;
            addItem(inputValue);
        });
 
        container.addEventListener("click", function(ev) {
            if (ev.target.tagName === "IMG") {
                var itemToRemove = ev.target.parentNode;
                var textForInput = itemToRemove.lastChild.nodeValue;
                itemToRemove.parentNode.removeChild(itemToRemove);
                input.value = textForInput;
            }
        });
    };
}