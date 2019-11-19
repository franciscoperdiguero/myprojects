$(document).ready(() => {

    loadTasks(false);
    loadTasks(true);



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


            notCompleted.append(task);

            db.collection('undoneTasks').add({
                done: inputText.val()
            });

            inputText.val("");
        }
    };

    function createTask(providedName, done) {
        let trash = $("<i class=\"fas fa-trash\"></i>");
        let icons = $("<div class='wrapIcons'></div>");
        if (done != true) {
            let tick = $("<i class=\"fas fa-check\"></i>");
            icons.append(tick, trash);
        } else {
            icons.append(trash);
        }
        let name = $("<label></label>").append(providedName);

        let task = $("<div class='task'></div>").append(name, icons);

        return task;
    }

    function loadTasks(done) {
        var collection;
        if (done == true) {
            collection = 'doneTasks';
        } else {
            collection = 'undoneTasks';
        }
        db.collection(collection).get().then((snapshot) => {
            snapshot.docs.forEach(doc => {
                var name = doc.data().task;
                var task = createTask(name, done);

                if (done == true) {
                    completed.append(task);
                } else {
                    notCompleted.append(task);
                }
            });
        });
    }
});
/*
function databaseRemove(name) {

    db.collection('undoneTasks').get().then((snapshots) => {
        snapshots.docs.forEach(doc => {
            if (doc.data().done == name) {
                db.collection('undoneTasks').doc(doc.id).delete();
                db.collection('doneTasks').add({
                    undone: name
                });
            }
        });
    });
};*/

