var Food = /** @class */ (function () {
    function Food(name, calories) {
        this._name = name;
        this._calories = calories;
    }
    Object.defineProperty(Food.prototype, "Name", {
        get: function () {
            return this._name;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Food.prototype, "Calories", {
        get: function () {
            return this._calories;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Food.prototype, "Taste", {
        get: function () { return this._taste; },
        set: function (value) {
            this._taste = value;
        },
        enumerable: false,
        configurable: true
    });
    return Food;
}());
//# sourceMappingURL=Food.js.map