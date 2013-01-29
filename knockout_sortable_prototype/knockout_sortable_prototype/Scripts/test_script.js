var Task = function (name) {
    this.name = ko.observable(name);
};

Task.prototype.clone = function () {
    return new Task(this.name());
};

var RubricItem = function (name, type) {
    this.name = ko.observable(name);

    /*Three types:
    0: Rubric Item
    1: Filled Item
    2: Blank Item
    */
    this.type = ko.observable(type);
    this.span = ko.observable(1);
}

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
    self.rows = ko.observableArray([
        ko.observableArray([new RubricItem('One', 0), new RubricItem('Two', 0), new RubricItem('Three', 0), new RubricItem('Blank', 2)]),
        ko.observableArray([new RubricItem('Four', 0), new RubricItem('Five', 0), new RubricItem('Blank', 2), new RubricItem('Filler', 1)]),
        ko.observableArray([new RubricItem('Blank', 2), new RubricItem('Blank', 2), new RubricItem('Filler', 1), new RubricItem('Filler', 1)])
    ]);

    self.addNewItem = function () {
        self.rows()[1].push('seven');
    };
};

ko.applyBindings(new ViewModel());
