var PractiseTests;
(function (PractiseTests) {
    var wwwroot;
    (function (wwwroot) {
        var ts;
        (function (ts) {
            var Shopper = /** @class */ (function () {
                function Shopper(firstname, lastname) {
                    this.firstname = firstname;
                    this.lastname = lastname;
                }
                Shopper.prototype.showName = function () {
                    alert("".concat(this.firstname, " {this.lastname}"));
                };
                return Shopper;
            }());
            var shopper = new Shopper("Priya", "Padmanabhan");
        })(ts = wwwroot.ts || (wwwroot.ts = {}));
    })(wwwroot = PractiseTests.wwwroot || (PractiseTests.wwwroot = {}));
})(PractiseTests || (PractiseTests = {}));
//# sourceMappingURL=shopper.js.map