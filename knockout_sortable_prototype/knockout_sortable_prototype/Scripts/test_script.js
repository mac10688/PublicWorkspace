var Task = function (name) {
    this.name = ko.observable(name);
};

Task.prototype.clone = function () {
    return new Task(this.name());
};

var ViewModel = function () {
    var self = this;

    self.Titles = ko.observableArray();
    self.newTitle = new Task("Title");
    self.allowNewTitle = ko.computed(function () {
        return self.Titles().length < 1;
    });

    self.Headers = ko.observableArray();    
    self.newHeader = new Task("Header");
    self.allowNewHeader = ko.computed(function () {
        return self.Headers().length < 5;
    });

    self.selectedTask = ko.observable();

    self.clearTask = function (data, event) {
        if (data === self.selectedTask()) {
            self.selectedTask(null);
        }

        if (data.name() === "") {
            self.Titles.remove(data);
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
