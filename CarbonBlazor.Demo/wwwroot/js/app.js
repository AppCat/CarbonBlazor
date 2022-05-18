(function $csb$eval(require, module, exports, process, global, __dirname, __filename, $csbImport) {
    var _csbRefreshUtils = require("/node_modules/csbbust/refresh-helper.js"); var prevRefreshReg = window.$RefreshReg$; var prevRefreshSig = window.$RefreshSig$; _csbRefreshUtils.prelude(module); try {
        "use strict";

        var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

        var _react = _interopRequireDefault(require("react"));

        var _reactRouterDom = require("react-router-dom");

        var _reactDom = require("react-dom");

        require("./styles.css");

        var _carbonComponentsReact = require("carbon-components-react");

        require("carbon-components/css/carbon-components.min.css");

        var _iconsReact = require("@carbon/icons-react");

        var _framerMotion = require("framer-motion");

        var _framer = require("framer");

        var _jsxRuntime = require("react/jsx-runtime");

        var _jsxFileName = "/src/index.js",
            _s = $RefreshSig$();

        const App = () => {
            _s();

            const history = (0, _reactRouterDom.useHistory)();
            const aiTypesData = [{
                id: 1,
                icon: () => /*#__PURE__*/(0, _jsxRuntime.jsx)(_iconsReact.CharacterPatterns16, {}),
                header: "Change risk",
                description: "Provides an assessment for the risk of deploying a code change. ",
                onViewDetails: () => history.push("/ai-types/change-risk")
            }, {
                id: 2,
                icon: () => /*#__PURE__*/(0, _jsxRuntime.jsx)(_iconsReact.EventSchedule16, {}),
                header: "Event grouping service",
                description: "Groups similar events that are related to each other through specific or related components of a service.",
                onViewDetails: () => { }
            }, {
                id: 3,
                icon: () => /*#__PURE__*/(0, _jsxRuntime.jsx)(_iconsReact.Activity16, {}),
                header: "Log anomaly detection",
                description: "Gathers log data from one to many individual components in the application architecture to discover abnormal behavior. ",
                onViewDetails: () => history.push("/ai-types/log-anomaly-detection")
            }, {
                id: 4,
                icon: () => /*#__PURE__*/(0, _jsxRuntime.jsx)(_iconsReact.ChartVennDiagram16, {}),
                header: "Similar incidents",
                description: "Discovers details about similar messages, anomalies, and events that occurred in the past and are impacting the current application.",
                onViewDetails: () => { }
            }, {
                id: 5,
                icon: () => /*#__PURE__*/(0, _jsxRuntime.jsx)(_iconsReact.CharacterPatterns16, {}),
                header: "Change risk",
                description: "Provides an assessment for the risk of deploying a code change. ",
                onViewDetails: () => history.push("/ai-types/change-risk")
            }, {
                id: 6,
                icon: () => /*#__PURE__*/(0, _jsxRuntime.jsx)(_iconsReact.EventSchedule16, {}),
                header: "Event grouping service",
                description: "Groups similar events that are related to each other through specific or related components of a service.",
                onViewDetails: () => { }
            }, {
                id: 7,
                icon: () => /*#__PURE__*/(0, _jsxRuntime.jsx)(_iconsReact.Activity16, {}),
                header: "Log anomaly detection",
                description: "Gathers log data from one to many individual components in the application architecture to discover abnormal behavior. ",
                onViewDetails: () => history.push("/ai-types/log-anomaly-detection")
            }, {
                id: 8,
                icon: () => /*#__PURE__*/(0, _jsxRuntime.jsx)(_iconsReact.ChartVennDiagram16, {}),
                header: "Similar incidents",
                description: "Discovers details about similar messages, anomalies, and events that occurred in the past and are impacting the current application.",
                onViewDetails: () => { }
            }];
            const cardVariants = {
                active: {
                    scale: 1.025,
                    transition: {
                        when: "beforeChildren",
                        duration: 0.2 // staggerChildren: 0.4

                    }
                },
                inactive: {
                    scale: 1
                }
            };
            const borderVariants = {
                inactive: {
                    opacity: 0,
                    background: "none"
                },
                active: {
                    opacity: 0 // height: "100%",
                    // transition: { duration: 0.2 }

                }
            };
            const icon = {
                inactive: {
                    opacity: 0,
                    pathLength: 0
                },
                active: {
                    opacity: 1,
                    pathLength: 1,
                    transition: {
                        duration: 0.5
                    }
                }
            };
            const bodyVariants = {
                initial: {
                    opacity: 0
                },
                animate: {
                    opacity: 1,
                    transition: {
                        when: "beforeChildren",
                        duration: 0.25,
                        staggerChildren: 0.2
                    }
                }
            };
            const cardContainerVariants = {
                initial: {
                    opacity: 0
                },
                animate: {
                    opacity: 1
                }
            };
            return /*#__PURE__*/(0, _jsxRuntime.jsx)(_framerMotion.AnimatePresence, {
                children: /*#__PURE__*/(0, _jsxRuntime.jsx)(_framerMotion.motion.div, {
                    className: "body",
                    variants: bodyVariants,
                    initial: "initial",
                    animate: "animate",
                    children: /*#__PURE__*/(0, _jsxRuntime.jsx)(_carbonComponentsReact.Grid, {
                        children: /*#__PURE__*/(0, _jsxRuntime.jsx)(_carbonComponentsReact.Row, {
                            children: aiTypesData.map((type, key) => {
                                return /*#__PURE__*/(0, _jsxRuntime.jsx)(_react.default.Fragment, {
                                    children: /*#__PURE__*/(0, _jsxRuntime.jsx)(_carbonComponentsReact.Column, {
                                        xlg: 4,
                                        lg: 4,
                                        md: 4,
                                        children: /*#__PURE__*/(0, _jsxRuntime.jsx)(_framerMotion.motion.div, {
                                            className: "container",
                                            variants: cardContainerVariants,
                                            children: /*#__PURE__*/(0, _jsxRuntime.jsxs)(_framerMotion.motion.div, {
                                                variants: cardVariants,
                                                initial: "inactive",
                                                whileHover: "active",
                                                animate: "inactive",
                                                className: "card",
                                                role: "link",
                                                "aria-label": "Link to details page",
                                                children: [/*#__PURE__*/(0, _jsxRuntime.jsx)(_framer.Frame, {
                                                    variants: borderVariants,
                                                    whileHover: {
                                                        border: "1px solid #0f62fe"
                                                    } // initial="inactive"
                                                    // animate="active"
                                                    ,
                                                    background: "none" // border="1px solid #0f62fe"
                                                    ,
                                                    height: "100%",
                                                    width: "100%",
                                                    style: {
                                                        position: "absolute",
                                                        left: "0",
                                                        top: "0"
                                                    }
                                                }), /*#__PURE__*/(0, _jsxRuntime.jsxs)("div", {
                                                    className: "card__content",
                                                    children: [/*#__PURE__*/(0, _jsxRuntime.jsx)(_framerMotion.motion.div, {
                                                        className: "card__icon",
                                                        children: type.icon()
                                                    }), /*#__PURE__*/(0, _jsxRuntime.jsx)("h2", {
                                                        className: "card__header",
                                                        children: type.header
                                                    }), /*#__PURE__*/(0, _jsxRuntime.jsx)("p", {
                                                        className: "card__description",
                                                        children: type.description
                                                    })]
                                                })]
                                            })
                                        })
                                    })
                                }, key);
                            })
                        })
                    })
                })
            });
        };

        _s(App, "9cZfZ04734qoCGIctmKX7+sX6eU=", false, function () {
            return [_reactRouterDom.useHistory];
        });

        _c = App;
        var _default = App;
        exports.default = _default;
        (0, _reactDom.render)( /*#__PURE__*/(0, _jsxRuntime.jsx)(App, {}), document.getElementById("root"));

        var _c;

        $RefreshReg$(_c, "App");
        //# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIi9zcmMvaW5kZXguanMiXSwibmFtZXMiOlsiQXBwIiwiaGlzdG9yeSIsImFpVHlwZXNEYXRhIiwiaWQiLCJpY29uIiwiaGVhZGVyIiwiZGVzY3JpcHRpb24iLCJvblZpZXdEZXRhaWxzIiwicHVzaCIsImNhcmRWYXJpYW50cyIsImFjdGl2ZSIsInNjYWxlIiwidHJhbnNpdGlvbiIsIndoZW4iLCJkdXJhdGlvbiIsImluYWN0aXZlIiwiYm9yZGVyVmFyaWFudHMiLCJvcGFjaXR5IiwiYmFja2dyb3VuZCIsInBhdGhMZW5ndGgiLCJib2R5VmFyaWFudHMiLCJpbml0aWFsIiwiYW5pbWF0ZSIsInN0YWdnZXJDaGlsZHJlbiIsImNhcmRDb250YWluZXJWYXJpYW50cyIsIm1hcCIsInR5cGUiLCJrZXkiLCJib3JkZXIiLCJwb3NpdGlvbiIsImxlZnQiLCJ0b3AiLCJ1c2VIaXN0b3J5IiwiZG9jdW1lbnQiLCJnZXRFbGVtZW50QnlJZCJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7O0FBQUE7O0FBQ0E7O0FBQ0E7O0FBRUE7O0FBRUE7O0FBQ0E7O0FBQ0E7O0FBTUE7O0FBQ0E7Ozs7Ozs7QUFFQSxNQUFNQSxHQUFHLEdBQUcsTUFBTTtBQUFBOztBQUNoQixRQUFNQyxPQUFPLEdBQUcsaUNBQWhCO0FBQ0EsUUFBTUMsV0FBVyxHQUFHLENBQ2xCO0FBQ0VDLElBQUFBLEVBQUUsRUFBRSxDQUROO0FBRUVDLElBQUFBLElBQUksRUFBRSxtQkFBTSxxQkFBQywrQkFBRCxLQUZkO0FBR0VDLElBQUFBLE1BQU0sRUFBRSxhQUhWO0FBSUVDLElBQUFBLFdBQVcsRUFDVCxrRUFMSjtBQU1FQyxJQUFBQSxhQUFhLEVBQUUsTUFBTU4sT0FBTyxDQUFDTyxJQUFSLENBQWEsdUJBQWI7QUFOdkIsR0FEa0IsRUFTbEI7QUFDRUwsSUFBQUEsRUFBRSxFQUFFLENBRE47QUFFRUMsSUFBQUEsSUFBSSxFQUFFLG1CQUFNLHFCQUFDLDJCQUFELEtBRmQ7QUFHRUMsSUFBQUEsTUFBTSxFQUFFLHdC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cUJxQixHQUFyQixDQURGO0FBMkRELFdBNURBO0FBREg7QUFERjtBQU5GO0FBREYsSUFERjtBQTRFRCxDQXpNRDs7R0FBTTNCLEc7VUFDWWdDLDBCOzs7S0FEWmhDLEc7ZUEyTVNBLEc7O0FBRWYsb0NBQU8scUJBQUMsR0FBRCxLQUFQLEVBQWdCaUMsUUFBUSxDQUFDQyxjQUFULENBQXdCLE1BQXhCLENBQWhCIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IFJlYWN0IGZyb20gXCJyZWFjdFwiO1xuaW1wb3J0IHsgdXNlSGlzdG9yeSB9IGZyb20gXCJyZWFjdC1yb3V0ZXItZG9tXCI7XG5pbXBvcnQgeyByZW5kZXIgfSBmcm9tIFwicmVhY3QtZG9tXCI7XG5cbmltcG9ydCBcIi4vc3R5bGVzLmNzc1wiO1xuXG5pbXBvcnQgeyBHcmlkLCBSb3csIENvbHVtbiB9IGZyb20gXCJjYXJib24tY29tcG9uZW50cy1yZWFjdFwiO1xuaW1wb3J0IFwiY2FyYm9uLWNvbXBvbmVudHMvY3NzL2NhcmJvbi1jb21wb25lbnRzLm1pbi5jc3NcIjtcbmltcG9ydCB7XG4gIEFjdGl2aXR5MTYsXG4gIENoYXJ0VmVubkRpYWdyYW0xNixcbiAgRXZlbnRTY2hlZHVsZTE2LFxuICBDaGFyYWN0ZXJQYXR0ZXJuczE2XG59IGZyb20gXCJAY2FyYm9uL2ljb25zLXJlYWN0XCI7XG5pbXBvcnQgeyBtb3Rpb24sIEFuaW1hdGVQcmVzZW5jZSB9IGZyb20gXCJmcmFtZXItbW90aW9uXCI7XG5pbXBvcnQgeyBGcmFtZSB9IGZyb20gXCJmcmFtZXJcIjtcblxuY29uc3QgQXBwID0gKCkgPT4ge1xuICBjb25zdCBoaXN0b3J5ID0gdXNlSGlzdG9yeSgpO1xuICBjb25zdCBhaVR5cGVzRGF0YSA9IFtcbiAgICB7XG4gICAgICBpZDogMSxcbiAgICAgIGljb246ICgpID0+IDxDaGFyYWN0ZXJQYXR0ZXJuczE2IC8+LFxuICAgICAgaGVhZGVyOiBcIkNoYW5nZSByaXNrXCIsXG4gICAgICBkZXNjcmlwdGlvbjpcbiAgICAgICAgXCJQcm92aWRlcyBhbiBhc3Nlc3NtZW50IGZvciB0aGUgcmlzayBvZiBkZXBsb3lpbmcgYSBjb2RlIGNoYW5nZS4gXCIsXG4gICAgICBvblZpZXdEZXRhaWxzOiAoKSA9PiBoaXN0b3J5LnB1c2goXCIvYWktdHlwZXMvY2hhbmdlLXJpc2tcIilcbiAgICB9LFxuICAgIHtcbiAgICAgIGlkOiAyLFxuICAgICAgaWNvbjogKCkgPT4gPEV2ZW50U2NoZWR1bGUxNiAvPixcbiAgICAgIGhlYWRlcjogXCJFdmVudCBncm91cGluZyBzZXJ2aWNlXCIsXG4gICAgICBkZXNjcmlwdGlvbjpcbiAgICAgICAgXCJHcm91cHMgc2ltaWxhciBldmVudHMgdGhhdCBhcmUgcmVsYXRlZCB0byBlYWNoIG90aGVyIHRocm91Z2ggc3BlY2lmaWMgb3IgcmVsYXRlZCBjb21wb25lbnRzIG9mIGEgc2VydmljZS5cIixcbiAgICAgIG9uVmlld0RldGFpbHM6ICgpID0+IHt9XG4gICAgfSxcbiAgICB7XG4gICAgICBpZDogMyxcbiAgICAgIGljb246ICgpID0+IDxBY3Rpdml0eTE2IC8+LFxuICAgICAgaGVhZGVyOiBcIkxvZyBhbm9tYWx5IGRldGVjdGlvblwiLFxuICAgICAgZGVzY3JpcHRpb246XG4gICAgICAgIFwiR2F0aGVycyBsb2cgZGF0YSBmcm9tIG9uZSB0byBtYW55IGluZGl2aWR1YWwgY29tcG9uZW50cyBpbiB0aGUgYXBwbGljYXRpb24gYXJjaGl0ZWN0dXJlIHRvIGRpc2NvdmVyIGFibm9ybWFsIGJlaGF2aW9yLiBcIixcbiAgICAgIG9uVmlld0RldGFpbHM6ICgpID0+IGhpc3RvcnkucHVzaChcIi9haS10eXBlcy9sb2ctYW5vbWFseS1kZXRlY3Rpb25cIilcbiAgICB9LFxuICAgIHtcbiAgICAgIGlkOiA0LFxuICAgICAgaWNvbjogKCkgPT4gPENoYXJ0VmVubkRpYWdyYW0xNiAvPixcbiAgICAgIGhlYWRlcjogXCJTaW1pbGFyIGluY2lkZW50c1wiLFxuICAgICAgZGVzY3JpcHRpb246XG4gICAgICAgIFwiRGlzY292ZXJzIGRldGFpbHMgYWJvdXQgc2ltaWxhciBtZXNzYWdlcywgYW5vbWFsaWVzLCBhbmQgZXZlbnRzIHRoYXQgb2NjdXJyZWQgaW4gdGhlIHBhc3QgYW5kIGFyZSBpbXBhY3RpbmcgdGhlIGN1cnJlbnQgYXBwbGljYXRpb24uXCIsXG4gICAgICBvblZpZXdEZXRhaWxzOiAoKSA9PiB7fVxuICAgIH0sXG4gICAge1xuICAgICAgaWQ6IDUsXG4gICAgICBpY29uOiAoKSA9PiA8Q2hhcmFjdGVyUGF0dGVybnMxNiAvPixcbiAgICAgIGhlYWRlcjogXCJDaGFuZ2Ugcmlza1wiLFxuICAgICAgZGVzY3JpcHRpb246XG4gICAgICAgIFwiUHJvdmlkZXMgYW4gYXNzZXNzbWVudCBmb3IgdGhlIHJpc2sgb2YgZGVwbG95aW5nIGEgY29kZSBjaGFuZ2UuIFwiLFxuICAgICAgb25WaWV3RGV0YWlsczogKCkgPT4gaGlzdG9yeS5wdXNoKFwiL2FpLXR5cGVzL2NoYW5nZS1yaXNrXCIpXG4gICAgfSxcbiAgICB7XG4gICAgICBpZDogNixcbiAgICAgIGljb246ICgpID0+IDxFdmVudFNjaGVkdWxlMTYgLz4sXG4gICAgICBoZWFkZXI6IFwiRXZlbnQgZ3JvdXBpbmcgc2VydmljZVwiLFxuICAgICAgZGVzY3JpcHRpb246XG4gICAgICAgIFwiR3JvdXBzIHNpbWlsYXIgZXZlbnRzIHRoYXQgYXJlIHJlbGF0ZWQgdG8gZWFjaCBvdGhlciB0aHJvdWdoIHNwZWNpZmljIG9yIHJlbGF0ZWQgY29tcG9uZW50cyBvZiBhIHNlcnZpY2UuXCIsXG4gICAgICBvblZpZXdEZXRhaWxzOiAoKSA9PiB7fVxuICAgIH0sXG4gICAge1xuICAgICAgaWQ6IDcsXG4gICAgICBpY29uOiAoKSA9PiA8QWN0aXZpdHkxNiAvPixcbiAgICAgIGhlYWRlcjogXCJMb2cgYW5vbWFseSBkZXRlY3Rpb25cIixcbiAgICAgIGRlc2NyaXB0aW9uOlxuICAgICAgICBcIkdhdGhlcnMgbG9nIGRhdGEgZnJvbSBvbmUgdG8gbWFueSBpbmRpdmlkdWFsIGNvbXBvbmVudHMgaW4gdGhlIGFwcGxpY2F0aW9uIGFyY2hpdGVjdHVyZSB0byBkaXNjb3ZlciBhYm5vcm1hbCBiZWhhdmlvci4gXCIsXG4gICAgICBvblZpZXdEZXRhaWxzOiAoKSA9PiBoaXN0b3J5LnB1c2goXCIvYWktdHlwZXMvbG9nLWFub21hbHktZGV0ZWN0aW9uXCIpXG4gICAgfSxcbiAgICB7XG4gICAgICBpZDogOCxcbiAgICAgIGljb246ICgpID0+IDxDaGFydFZlbm5EaWFncmFtMTYgLz4sXG4gICAgICBoZWFkZXI6IFwiU2ltaWxhciBpbmNpZGVudHNcIixcbiAgICAgIGRlc2NyaXB0aW9uOlxuICAgICAgICBcIkRpc2NvdmVycyBkZXRhaWxzIGFib3V0IHNpbWlsYXIgbWVzc2FnZXMsIGFub21hbGllcywgYW5kIGV2ZW50cyB0aGF0IG9jY3VycmVkIGluIHRoZSBwYXN0IGFuZCBhcmUgaW1wYWN0aW5nIHRoZSBjdXJyZW50IGFwcGxpY2F0aW9uLlwiLFxuICAgICAgb25WaWV3RGV0YWlsczogKCkgPT4ge31cbiAgICB9XG4gIF07XG5cbiAgY29uc3QgY2FyZFZhcmlhbnRzID0ge1xuICAgIGFjdGl2ZToge1xuICAgICAgc2NhbGU6IDEuMDI1LFxuICAgICAgdHJhbnNpdGlvbjoge1xuICAgICAgICB3aGVuOiBcImJlZm9yZUNoaWxkcmVuXCIsXG4gICAgICAgIGR1cmF0aW9uOiAwLjJcbiAgICAgICAgLy8gc3RhZ2dlckNoaWxkcmVuOiAwLjRcbiAgICAgIH1cbiAgICB9LFxuICAgIGluYWN0aXZlOiB7IHNjYWxlOiAxIH1cbiAgfTtcblxuICBjb25zdCBib3JkZXJWYXJpYW50cyA9IHtcbiAgICBpbmFjdGl2ZTogeyBvcGFjaXR5OiAwLCBiYWNrZ3JvdW5kOiBcIm5vbmVcIiB9LFxuICAgIGFjdGl2ZToge1xuICAgICAgb3BhY2l0eTogMFxuICAgICAgLy8gaGVpZ2h0OiBcIjEwMCVcIixcbiAgICAgIC8vIHRyYW5zaXRpb246IHsgZHVyYXRpb246IDAuMiB9XG4gICAgfVxuICB9O1xuXG4gIGNvbnN0IGljb24gPSB7XG4gICAgaW5hY3RpdmU6IHtcbiAgICAgIG9wYWNpdHk6IDAsXG4gICAgICBwYXRoTGVuZ3RoOiAwXG4gICAgfSxcbiAgICBhY3RpdmU6IHtcbiAgICAgIG9wYWNpdHk6IDEsXG4gICAgICBwYXRoTGVuZ3RoOiAxLFxuICAgICAgdHJhbnNpdGlvbjogeyBkdXJhdGlvbjogMC41IH1cbiAgICB9XG4gIH07XG5cbiAgY29uc3QgYm9keVZhcmlhbnRzID0ge1xuICAgIGluaXRpYWw6IHtcbiAgICAgIG9wYWNpdHk6IDBcbiAgICB9LFxuICAgIGFuaW1hdGU6IHtcbiAgICAgIG9wYWNpdHk6IDEsXG4gICAgICB0cmFuc2l0aW9uOiB7XG4gICAgICAgIHdoZW46IFwiYmVmb3JlQ2hpbGRyZW5cIixcbiAgICAgICAgZHVyYXRpb246IDAuMjUsXG4gICAgICAgIHN0YWdnZXJDaGlsZHJlbjogMC4yXG4gICAgICB9XG4gICAgfVxuICB9O1xuXG4gIGNvbnN0IGNhcmRDb250YWluZXJWYXJpYW50cyA9IHtcbiAgICBpbml0aWFsOiB7XG4gICAgICBvcGFjaXR5OiAwXG4gICAgfSxcbiAgICBhbmltYXRlOiB7XG4gICAgICBvcGFjaXR5OiAxXG4gICAgfVxuICB9O1xuXG4gIHJldHVybiAoXG4gICAgPEFuaW1hdGVQcmVzZW5jZT5cbiAgICAgIDxtb3Rpb24uZGl2XG4gICAgICAgIGNsYXNzTmFtZT1cImJvZHlcIlxuICAgICAgICB2YXJpYW50cz17Ym9keVZhcmlhbnRzfVxuICAgICAgICBpbml0aWFsPVwiaW5pdGlhbFwiXG4gICAgICAgIGFuaW1hdGU9XCJhbmltYXRlXCJcbiAgICAgID5cbiAgICAgICAgPEdyaWQ+XG4gICAgICAgICAgPFJvdz5cbiAgICAgICAgICAgIHthaVR5cGVzRGF0YS5tYXAoKHR5cGUsIGtleSkgPT4ge1xuICAgICAgICAgICAgICByZXR1cm4gKFxuICAgICAgICAgICAgICAgIDxSZWFjdC5GcmFnbWVudCBrZXk9e2tleX0+XG4gICAgICAgICAgICAgICAgICA8Q29sdW1uIHhsZz17NH0gbGc9ezR9IG1kPXs0fT5cbiAgICAgICAgICAgICAgICAgICAgPG1vdGlvbi5kaXZcbiAgICAgICAgICAgICAgICAgICAgICBjbGFzc05hbWU9XCJjb250YWluZXJcIlxuICAgICAgICAgICAgICAgICAgICAgIHZhcmlhbnRzPXtjYXJkQ29udGFpbmVyVmFyaWFudHN9XG4gICAgICAgICAgICAgICAgICAgID5cbiAgICAgICAgICAgICAgICAgICAgICA8bW90aW9uLmRpdlxuICAgICAgICAgICAgICAgICAgICAgICAgdmFyaWFudHM9e2NhcmRWYXJpYW50c31cbiAgICAgICAgICAgICAgICAgICAgICAgIGluaXRpYWw9XCJpbmFjdGl2ZVwiXG4gICAgICAgICAgICAgICAgICAgICAgICB3aGlsZUhvdmVyPVwiYWN0aXZlXCJcbiAgICAgICAgICAgICAgICAgICAgICAgIGFuaW1hdGU9XCJpbmFjdGl2ZVwiXG4gICAgICAgICAgICAgICAgICAgICAgICBjbGFzc05hbWU9XCJjYXJkXCJcbiAgICAgICAgICAgICAgICAgICAgICAgIHJvbGU9XCJsaW5rXCJcbiAgICAgICAgICAgICAgICAgICAgICAgIGFyaWEtbGFiZWw9XCJMaW5rIHRvIGRldGFpbHMgcGFnZVwiXG4gICAgICAgICAgICAgICAgICAgICAgPlxuICAgICAgICAgICAgICAgICAgICAgICAgPEZyYW1lXG4gICAgICAgICAgICAgICAgICAgICAgICAgIHZhcmlhbnRzPXtib3JkZXJWYXJpYW50c31cbiAgICAgICAgICAgICAgICAgICAgICAgICAgd2hpbGVIb3Zlcj17eyBib3JkZXI6IFwiMXB4IHNvbGlkICMwZjYyZmVcIiB9fVxuICAgICAgICAgICAgICAgICAgICAgICAgICAvLyBpbml0aWFsPVwiaW5hY3RpdmVcIlxuICAgICAgICAgICAgICAgICAgICAgICAgICAvLyBhbmltYXRlPVwiYWN0aXZlXCJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgYmFja2dyb3VuZD1cIm5vbmVcIlxuICAgICAgICAgICAgICAgICAgICAgICAgICAvLyBib3JkZXI9XCIxcHggc29saWQgIzBmNjJmZVwiXG4gICAgICAgICAgICAgICAgICAgICAgICAgIGhlaWdodD1cIjEwMCVcIlxuICAgICAgICAgICAgICAgICAgICAgICAgICB3aWR0aD1cIjEwMCVcIlxuICAgICAgICAgICAgICAgICAgICAgICAgICBzdHlsZT17eyBwb3NpdGlvbjogXCJhYnNvbHV0ZVwiLCBsZWZ0OiBcIjBcIiwgdG9wOiBcIjBcIiB9fVxuICAgICAgICAgICAgICAgICAgICAgICAgPlxuICAgICAgICAgICAgICAgICAgICAgICAgICB7LyogPG1vdGlvbi5zdmdcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICB4bWxucz1cImh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnXCJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAvLyB2aWV3Qm94PVwiMCAwIDYxMCAxMzQwXCJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAvLyBwcmVzZXJ2ZUFzcGVjdFJhdGlvPVwibm9uZVwiXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgc3R5bGU9e3sgd2lkdGg6IFwiMTAwJVwiLCBoZWlnaHQ6IFwiMTAwJVwiIH19XG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgY2xhc3NOYW1lPVwiY2FyZF9fYm9yZGVyXCJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgPlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxtb3Rpb24ucGF0aFxuICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgcHJlc2VydmVBc3BlY3RSYXRpbz1cIm5vbmVcIlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgZD1cIk0xIDEgTDEgMTY3IEwzMzggMTY3IEwzMzggMSBaXCJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHN0eWxlPXt7IGZpbGw6IFwibm9uZVwiLCBzdHJva2U6IFwiIzBmNjJmZVwiIH19XG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICB2YXJpYW50cz17aWNvbn1cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHRyYW5zaXRpb249e3tcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgZGVmYXVsdDogeyBkdXJhdGlvbjogMC4yLCBlYXNlOiBcImVhc2VJbk91dFwiIH1cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIH19XG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgLz5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgPC9tb3Rpb24uc3ZnPiAqL31cbiAgICAgICAgICAgICAgICAgICAgICAgIDwvRnJhbWU+XG4gICAgICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cImNhcmRfX2NvbnRlbnRcIj5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgPG1vdGlvbi5kaXYgY2xhc3NOYW1lPVwiY2FyZF9faWNvblwiPlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIHt0eXBlLmljb24oKX1cbiAgICAgICAgICAgICAgICAgICAgICAgICAgPC9tb3Rpb24uZGl2PlxuICAgICAgICAgICAgICAgICAgICAgICAgICA8aDIgY2xhc3NOYW1lPVwiY2FyZF9faGVhZGVyXCI+e3R5cGUuaGVhZGVyfTwvaDI+XG4gICAgICAgICAgICAgICAgICAgICAgICAgIDxwIGNsYXNzTmFtZT1cImNhcmRfX2Rlc2NyaXB0aW9uXCI+XG4gICAgICAgICAgICAgICAgICAgICAgICAgICAge3R5cGUuZGVzY3JpcHRpb259XG4gICAgICAgICAgICAgICAgICAgICAgICAgIDwvcD5cbiAgICAgICAgICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgICAgICAgICAgIDwvbW90aW9uLmRpdj5cbiAgICAgICAgICAgICAgICAgICAgPC9tb3Rpb24uZGl2PlxuICAgICAgICAgICAgICAgICAgPC9Db2x1bW4+XG4gICAgICAgICAgICAgICAgPC9SZWFjdC5GcmFnbWVudD5cbiAgICAgICAgICAgICAgKTtcbiAgICAgICAgICAgIH0pfVxuICAgICAgICAgIDwvUm93PlxuICAgICAgICA8L0dyaWQ+XG4gICAgICA8L21vdGlvbi5kaXY+XG4gICAgPC9BbmltYXRlUHJlc2VuY2U+XG4gICk7XG59O1xuXG5leHBvcnQgZGVmYXVsdCBBcHA7XG5cbnJlbmRlcig8QXBwIC8+LCBkb2N1bWVudC5nZXRFbGVtZW50QnlJZChcInJvb3RcIikpO1xuIl19
        _csbRefreshUtils.postlude(module);
    } finally { window.$RefreshReg$ = prevRefreshReg; window.$RefreshSig$ = prevRefreshSig; }
    //# sourceURL=https://81wuw.csb.app/src/index.js
})