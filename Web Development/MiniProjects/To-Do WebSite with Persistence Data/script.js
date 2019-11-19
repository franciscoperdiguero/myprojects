
var inputText = $(".inputText input");
const button = $(".inputText #btn1")

const notCompleted = $(".remainingTask");
const completed = $(".completedTask");


inputText.on("keyup", (e) => {
    addATask(e);
});

button.on("click", (e) => {
    addATask(e);
});

$(document).on("click", ".task .fa-trash", (e) => {
    removeTask(e);
});

$(document).on("click", ".task .fa-check", (e) => {
    var p = $(e.currentTarget.parentNode.parentNode);
    var name = p.find("label").text();

    databaseRemove(name);

    p.find(".fa-check").remove();

    p.fadeOut(function () {
        p.remove();
        completed.append(p);
        p.fadeIn();
    });
});


function removeTask(e) {
    var p = $(e.currentTarget.parentNode.parentNode);
    p.fadeOut(function () {
        p.remove();
    });
}

function addATask(e) {
    e.preventDefault();
    if ((e.keyCode == 13 || e.button == 0) && inputText.val() != "") {

        let tick = $("<i class=\"fas fa-check\"></i>");
        let trash = $("<i class=\"fas fa-trash\"></i>");
        let icons = $("<div class='wrapIcons'></div>").append(tick, trash);
        let name = $("<label></label>").append(inputText.val());

        let task = $("<div class='task'></div>").append(name, icons);
        notCompleted.append(task);

        db.collection('doneTasks').add({
            done: inputText.val()
        });

        inputText.val("");
    }
};

function databaseRemove(name) {

    db.collection('doneTasks').get().then((snapshots) => {
        snapshots.docs.forEach(doc => {
            if (doc.data().done == name) {
                db.collection('doneTasks').doc(doc.id).delete();
                db.collection('undoneTasks').add({
                    undone: name
                });
            }
        });
    });

};

