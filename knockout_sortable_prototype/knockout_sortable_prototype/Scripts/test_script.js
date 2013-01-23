var Task = function (name) {
    this.name = ko.observable(name);
};

Task.prototype.clone = function () {
    return new Task(this.name());
};

var ViewModel = function () {
    var self = this;
    self.tasks = ko.observableArray([
        new Task("Get dog food"),
        new Task("Mow lawn"),
        new Task("Fix car"),
        new Task("Fix fence"),
        new Task("Walk dog"),
        new Task("Read book")
    ]);

    self.newTask = new Task("New Task");

    self.allowNewTask = ko.computed(function () {
        return self.tasks().length < 10;
    });

    self.selectedTask = ko.observable();

    self.clearTask = function (data, event) {
        if (data === self.selectedTask()) {
            self.selectedTask(null);
        }

        if (data.name() === "") {
            self.tasks.remove(data);
        }
    };

    self.isTaskSelected = function (task) {
        return task === self.selectedTask();
    };
};

//control visibility, give element focus, and select the contents (in order)
ko.bindingHandlers.visibleAndSelect = {
    update: function (element, valueAccessor) {
        ko.bindingHandlers.visible.update(element, valueAccessor);
        if (valueAccessor()) {
            setTimeout(function () {
                $(element).find("input").focus().select();
            }, 0); //new tasks are not in DOM yet
        }
    }
};

ko.applyBindings(new ViewModel());
