/*
Inputs: evt - Holds the current selected tab that is selected | tabName - The new tab that is to be shown
Remarks: When tab button is clicked hide the current table that is shown and show the table that is selected.
*/
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
/*
Inputs: input -  Name of button which needs the text input shown
Remarks: Toggles colour of button and displays input text if button is active else hides text input
*/
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
/*
Remarks: If at least one button is active then show the submit button otherwise the button should be hidden
*/
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
/*
Inputs: table - The table name that is to be copied
Remarks: If no copy buttons selected then copy all fields, otherwise construct the contents for the clipboard
so that it only has those fields which are selected
*/
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
/*
Inputs: buttonID - The name of the copy button which has just been clicked | table - The table that the selected button belongs to
Remarks: Toggle the colour of button so that if it hasn't been selected it is now showing it is selected and vice versa
*/
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
/*
Inputs: table - The table this dropdown button belongs to
Remarks: Toggles the visibily of the copy buttons dropdown for the appropriate table
*/
function showCopyDropdown(table) {
	document.getElementById(table+"Dropdown").classList.toggle("show");
}
/*
Inputs: tableName - The table to be demolished and displayed
Remarks: Regardless if the table is populated or not it has its contents cleared and then the 
table and copy buttons are made visible
*/
function tableDemolisherAndDisplayer(tableName) {
	for (var i = document.getElementById(tableName + "ResultsTable").rows.length; i > 0; i--) {
		document.getElementById(tableName + "ResultsTable").deleteRow(i - 1);
	}
	document.getElementById(tableName + "Container").style.display = "block";
	document.getElementById(tableName + "copyButton").innerHTML = '&#x1F4CB';
	document.getElementById(tableName + "copyButton").style.display = 'block';
	document.getElementById(tableName + "copySelectButton").style.display = "block";
}
/*
Inputs: chosenFields - The selected fields that are to be copied
Remarks: Adds the fields to the clipboardContents string. Removing special characters, 
adding a tab after every field value and a new line after every record.
*/
function constructClipboard(chosenFields) {
	let queryResults = JSON.parse(document.getElementById("queryResults").innerHTML);
	let clipboardContents = "";
	for (let curRecord in queryResults) {
		let record = queryResults[curRecord];
		for (let chosenField in chosenFields) {
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
/*
Inputs: queryResults - The object returned from the Controller | tableName - The table to be populated | headers - The chosen fields for said table
Remarks: If queryResults is empty then display message saying such. Else create a header row to the table and append
the headers to it. Then fill each appropriate field value to its corresponding header until all records are displayed,
ensuring that duplicate records are not displayed
*/
function tableBuilder(queryResults, tableName, headers) {
	let recordCount = 0;
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
				++recordCount;
			}
		}
		console.log(tableName);
		document.getElementById('recordCount' + tableName).innerHTML = "Total Record Count: " + recordCount;
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