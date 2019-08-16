
function changeTab(evt, tabName) {
	var i, tabcontent, tablinks;

	tabcontent = document.getElementsByClassName("tabcontent");
	for (i = 0; i < tabcontent.length; i++) {
		tabcontent[i].style.display = "none";
	}

	tablinks = document.getElementsByClassName("tablinks");
	for (i = 0; i < tablinks.length; i++) {
		tablinks[i].className = tablinks[i].className.replace(" active", "");
	}

	document.getElementById(tabName).style.display = "block";
	evt.currentTarget.tabName += " active";
}
function showInput(input) {
	let inputText = document.getElementById(input);
	let inputTextTitle = document.getElementById(input + "Text");
	let button = document.getElementById(input + "Button");
	if (inputText.style.display == "none" || button.style.backgroundColor == "") {
		inputText.value = "";
		inputText.style.display = "block";
		inputTextTitle.style.display = "block";
		button.style.backgroundColor = "#20A64B"
		button.style.borderColor = "#20A64B"
	} else {
		inputText.style.display = "none";
		inputTextTitle.style.display = "none";
		button.style.backgroundColor = "#f1f3f2";
		button.style.borderColor = "#F9B123"
	}
	showSubmit();
}
function showSubmit() {
	let btnNames = getBtnNames();
	let active = 0;
	for (let button in btnNames) {
		if (document.getElementById(btnNames[button] + "InputButton").style.backgroundColor === "rgb(32, 166, 75)") {
			++active;
			document.getElementById("submitButton").style.display = "block";
		}
	}
	if (active == 0) {
		document.getElementById("submitButton").style.display = "none";
	}
}
function copy(table) {
	let btnNames = getCopyBtnNames(table);
	let classNames = getCopyFields(table);
	let chosenFields = [];
	for (let button in btnNames) {
		if (document.getElementById(btnNames[button] + "CopyButton").style.backgroundColor == "rgb(32, 166, 75)") {
			chosenFields.push(classNames[button]);
		}
	}
	if (chosenFields.length == 0) {
		chosenFields = classNames;
	}
	console.log(chosenFields);
	constructClipboard(chosenFields);
	let clipboardContents = document.getElementById("clipboard").innerHTML;
	let itemsToCopy = document.createElement("textarea");
	document.body.appendChild(itemsToCopy);
	itemsToCopy.value = clipboardContents;
	itemsToCopy.select();
	document.execCommand("copy");
	console.log("copied!");
	document.body.removeChild(itemsToCopy);
	document.getElementById(table+"copyButton").innerHTML = '&#10004';
}
function copySelectButton(buttonID, table) {
	currentColour = document.getElementById(buttonID + "Button").style.backgroundColor;
	document.getElementById(table+"copyButton").innerHTML = '&#x1F4CB';
	if (currentColour == "rgb(241, 243, 242)" || currentColour == "") {
		document.getElementById(buttonID + "Button").style.backgroundColor = "#20A64B";
	}
	else {
		document.getElementById(buttonID + "Button").style.backgroundColor = "#f1f3f2";
	}
}
function showCopyDropdown(table) {
	document.getElementById(table+"Dropdown").classList.toggle("show");
}
function tableDemolisherAndDisplayer(tableName) {
	//Demolisher
	for (var i = document.getElementById(tableName + "ResultsTable").rows.length; i > 0; i--) {
		document.getElementById(tableName + "ResultsTable").deleteRow(i - 1);
	}
	//Displayer
	document.getElementById(tableName + "Container").style.display = "block";
	document.getElementById(tableName + "copyButton").innerHTML = '&#x1F4CB';
	document.getElementById(tableName + "copyButton").style.display = 'block';
	document.getElementById(tableName + "copySelectButton").style.display = "block";
}
function constructClipboard(chosenFields) {
	let queryResults = JSON.parse(document.getElementById("queryResults").innerHTML);
	let clipboardContents = "";
	for (let curRecord in queryResults) {
		let record = queryResults[curRecord];
		for (let chosenField in chosenFields) {
			console.log(JSON.stringify(record[chosenFields[chosenField]]));
			if (record[chosenFields[chosenField]] != null) {
				if (record[chosenFields[chosenField]].includes("\r")) {
					clipboardContents += "\t" + record[chosenFields[chosenField]].replace(/\r/g, ", ");
				} else {
					clipboardContents += "\t" + record[chosenFields[chosenField]];
				}
			} else {
				clipboardContents += "\t";
			}
		}
		clipboardContents += "\n";
	}
	document.getElementById("clipboard").innerHTML = clipboardContents;
}
function tableBuilder(queryResults, tableName, headers) {
	let table = document.getElementById(tableName);
	let headerTable = table.createTHead();
	let headerRowTable = table.insertRow(0);
	if (queryResults.length == 0) {
		let curHeaderCell = headerRowTable.insertCell(-1);
		curHeaderCell.innerHTML = "The query failed to return any results";
	}
	else {
		let tableHeaders = Object.keys(queryResults[0]).filter(word => headers.includes(word));
		let discardedHeaders = Object.keys(queryResults[0]).filter(word => !headers.includes(word));
		for (let i = 0; i < tableHeaders.length; ++i) {
			let curHeaderCell = headerRowTable.insertCell(-1);
			curHeaderCell.innerHTML = tableHeaders[i].replace(/_/g, " ");
		}
		let newInputs = [];
		for (let record in queryResults) {
			let newRecord = {};
			tableHeaders.forEach(function (header) {
				let curRecord = queryResults[record];
				newRecord[header] = curRecord[header];
			});
			let recordsEqual = newInputs.map(curRecord => _.isEqual(newRecord, curRecord));
			if (!recordsEqual.includes(true)) {
				newInputs.push(newRecord);
			}
		}
		for (let record in newInputs) {
			let curRecord = newInputs[record];
			let recordValues = Object.values(newInputs[record]);
			let curRecordRow = table.insertRow(-1);
			for (let i = 0; i < tableHeaders.length; ++i) {
				let curRecordCell = curRecordRow.insertCell(-1);
				curRecordCell.innerHTML = recordValues[i];
			}
		}
	}
}