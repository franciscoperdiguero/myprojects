// Object for controlling displays
var display1 = {
    operation: "0",
    evaluation: "",
    answer: ""
};

//Control flags
var flag = {
    standardMode: true,
    scientificMode: false
};

function evaluate() {
    try {
        display1.evaluation = math.format(math.evaluate(display1.operation),
            { notation: 'auto', precision: 8, lowerExp: -7, upperExp: 7 }); //Math.js function
        return true; // no exception occured
    } catch (e) {
        if (e instanceof SyntaxError) { // Syntax error exception
            display1.evaluation = "Syntax Error";
            return false; // exception occured
        }
        else {// Unspecified exceptions
            display1.evaluation = "Error";
            return false; // exception occured
        }
    }
}

function clearDisplay() {
    if ($('#display1').val() === "0") {
        $('#display1').val("");
        display1.operation = "";
    }
}

const keys = $('.numbers');
keys.click((event) => {
    const { target } = event;

    //Check what is pressed is a button or not. Prevent event propagation.
    if (!target.matches('button')) {
        return;
    }

    //After press any key, if there was an error, clean the display
    if ($('#display1').val() === "Syntax Error" || $('#display1').val() === "Error") {
        display1.evaluation = "";
        display1.operation = "";
        $('#display1').val("");
    }

    //You can use any variable (Ans or PI)
    if (target.classList.contains('variable')) {
        clearDisplay();

        var valueAux = "";
        var displayAux = "";
        if (target.classList.contains('pi')) {
            varAux = math.pi;
            displayAux = 'π';
        }

        if (target.classList.contains('ans')) {
            varAux = display1.answer.toString();
            displayAux = 'Ans';
        }

        display1.operation = display1.operation.toString() + '(' + varAux + ')';
        $('#display1').val($('#display1').val() + displayAux);
        return;
    }

    //After press EXP button, you can use big numbers
    if (target.classList.contains('e')) {
        display1.operation = display1.operation + 'e';
        $('#display1').val($('#display1').val() + 'e');
        return;
    }

    //Calculate any function(abs, sqrt, sin, cos, tan)
    if (target.classList.contains('function')) {
        display1.operation = target.value + '(' + display1.operation + ')';

        //After press square root key, evaluates square root. It's important to introduce an expression and after that,
        //calculate a square root.
        if (target.classList.contains('squareRoot')) {
            $('#display1').val('√(' + $('#display1').val() + ')');
        } else { //sin, cos, tan, abs
            $('#display1').val(target.value + '(' + $('#display1').val() + ')');
        }
        return;
    }

    //After press Ans button, adds answer value saved in display1.answer
    if (target.classList.contains('ans')) {
        clearDisplay();
        display1.operation = display1.operation.toString() + "(" + display1.answer.toString() + ")";
        $('#display1').val($('#display1').val() + 'Ans');
        return;
    }

    //After press equal key, answer value is stored with evaluated value.
    if (target.classList.contains('equal')) {
        evaluate();
        $('#display1').val(display1.evaluation); // Update display1
        if (!(display1.evaluation === "Syntax Error" || display1.evaluation === "Error")) {
            display1.answer = display1.evaluation; // Store the answer (Ans button)
            display1.operation = display1.answer; // Current operation equals the answer
            $('.ans').attr('disabled', false);
        }
        return;
    }

    //After press backspace, removes the last digit/operator introduced.
    if (target.classList.contains('backspace')) {
        display1.operation = display1.operation.toString().slice(0, display1.operation.length - 1);
        $('#display1').val($('#display1').val().slice(0, $('#display1').val().length - 1));
        if ($('#display1').val() === "") {
            $('#display1').val("0")
        }
        return;
    }

    //After press AC key, all values are reset.
    if (target.classList.contains('clear')) {
        display1.operation = "0";
        display1.evaluation = "";
        $('#display1').val("0");
        return;
    }

    //After press any different key, value is added to the expression to be evaluated.
    if (!target.classList.contains('power')) {
        clearDisplay();
    }
    display1.operation = display1.operation + target.value;
    $('#display1').val($('#display1').val() + target.value);
});

/* EXTRA FUNCTIONS FOR DESIGN */

/* Open the sidenav */
function openNav() {
    $("#mySidenav").css("width", "100%");
}

/* Close/hide the sidenav */
function closeNav() {
    $("#mySidenav").css("width", "0");
}


//Set different modes
function standardMode() {
    if (!flag.standardMode) {
        $(".scientific").css("display", "none");
        $(".numbers").css("grid-template-columns", "repeat(4, 1fr)");
        flag.standardMode = true;
        flag.scientificMode = false;
    }
    closeNav();
}

function scientificMode() {
    if (!flag.scientificMode) {
        $(".scientific").css("display", "block");
        $(".numbers").css("grid-template-columns", "repeat(5, 1fr)");
        flag.scientificMode = true;
        flag.standardMode = false;
    }
    closeNav();
}
