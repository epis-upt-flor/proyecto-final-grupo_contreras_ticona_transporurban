
javascript
/*
 * jQuery UI addresspicker @VERSION
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * Depends:
 *   jquery.ui.core.js
 *   jquery.ui.widget.js
 *   jquery.ui.autocomplete.js
 */
(function( $, undefined ) {

  $.widget( "ui.addresspicker", {
    options: {
        appendAddressString: "",
        draggableMarker: true,
        regionBias: null,
        bounds: '',
        componentsFilter:'',
        updateCallback: null,
        reverseGeocode: false,
        autocomplete: 'default',
        language: '',
        mapOptions: {
            zoom: 5,
            center: [2, 46], // Longitud, Latitud
            scrollwheel: false
        },
        elements: {
            map: false,
            lat: false,
            lng: false,
            street_number: false,
            route: false,
            locality: false,
            sublocality: false,
            administrative_area_level_3: false,
            administrative_area_level_2: false,
            administrative_area_level_1: false,
            country: false,
            postal_code: false,
            type: false
        },
        autocomplete: '' // could be autocomplete: "bootstrap" to use bootstrap typeahead autocomplete instead of jQueryUI
    },

    marker: function() {
      return this.gmarker;
    },

    map: function() {
      return this.gmap;
    },

    updatePosition: function() {
      this._updatePosition(this.gmarker.getLngLat());
    },

    reloadPosition: function() {
      this.gmarker.setLngLat([this.lng.val(), this.lat.val()]);
      this.gmarker.addTo(this.gmap);
      this.gmap.setCenter(this.gmarker.getLngLat());
    },

    resize: function() {
      this.gmap.resize()
    },

    selected: function() {
      return this.selectedResult;
    },
    _mapped: {},
    _create: function() {
      var self = this;

      if (this.options.autocomplete === 'bootstrap') {
          this.element.typeahead({
            source: function(query, process) {
                self._mapped = {};
                var response = function(results) {
                    var labels = [];
                    for (var i = 0; i < results.length; i++) {
                        self._mapped[results[i].label] = results[i];
                        labels.push(results[i].label);
                    }
                    process(labels);
                };
                var request = {term: query};
                self._geocode(request, response);
            },
            updater: function(item) {
                var ui = {item: self._mapped[item]}
                self._focusAddress(null, ui);
                self._selectAddress(null, ui);
                return item;
            }
          });
      } else {
        this.element.autocomplete($.extend({
            source: $.proxy(this._geocode, this),
            focus:  $.proxy(this._focusAddress, this),
            select: $.proxy(this._selectAddress, this)
        }), this.options.autocomplete);
      }

      this.lat      = $(this.options.elements.lat);
      this.lng      = $(this.options.elements.lng);
      this.street_number = $(this.options.elements.street_number);
      this.route = $(this.options.elements.route);
      this.locality = $(this.options.elements.locality);
      this.sublocality = $(this.options.elements.sublocality);
      this.administrative_area_level_3 = $(this.options.elements.administrative_area_level_3);
      this.administrative_area_level_2 = $(this.options.elements.administrative_area_level_2);
      this.administrative_area_level_1 = $(this.options.elements.administrative_area_level_1);
      this.country  = $(this.options.elements.country);
      this.postal_code = $(this.options.elements.postal_code);
      this.type     = $(this.options.elements.type);
      if (this.options.elements.map) {
        this.mapElement = $(this.options.elements.map);
        this._initMap();
      }
    },

    _initMap: function() {
      if (this.lat && this.lat.val()) {
        this.options.mapOptions.center = [this.lng.val(), this.lat.val()];
      }

      mapboxgl.accessToken = 'pk.eyJ1IjoibXVyZ3VpYTIxIiwiYSI6ImNsd3diamdoZjExNGkyam9sMjViaW55N3QifQ.8P11bforeLcA3aCKYALiJw'; // Reemplaza con tu Access Token de Mapbox

      this.gmap = new mapboxgl.Map({
        container: this.mapElement[0],
        style: 'mapbox://styles/mapbox/streets-v11',
        center: this.options.mapOptions.center,
        zoom: this.options.mapOptions.zoom,
        scrollZoom: this.options.mapOptions.scrollwheel ? 'enabled' : 'disabled'
      });
      this.gmarker = new mapboxgl.Marker({
        draggable: this.options.draggableMarker
      });
      this.gmarker.setLngLat(this.options.mapOptions.center);
      this.gmarker.addTo(this.gmap);

      this.gmarker.on('dragend', $.proxy(this._markerMoved, this));
    },

    _updatePosition: function(location) {
      if (this.lat) {
        this.lat.val(location.lat);
      }
      if (this.lng) {
        this.lng.val(location.lng);
      }
    },

    _geocode: function(request, response) {
        var address = request.term,
            self = this;

        fetch('https://api.mapbox.com/geocoding/v5/mapbox.places/' + address + '.json?access_token=' + mapboxgl.accessToken)
        .then(function(response) {
            return response.json();
        })
        .then(function(data) {
            var results = data.features.map(function(feature) {
                return {
                    label: feature.place_name,
                    value: feature.place_name,
                    geometry: {
                        location: {
                            lat: feature.center[1],
                            lng: feature.center[0]
                        },
                        viewport: {
                            northeast: {
                                lat: feature.bbox ? feature.bbox[3] : null,
                                lng: feature.bbox ? feature.bbox[2] : null
                            },
                            southwest: {
                                lat: feature.bbox ? feature.bbox[1] : null,
                                lng: feature.bbox ? feature.bbox[0] : null
                            }
                        }
                    }
                };
            });
            response(results);
        })
        .catch(function(error) {
            console.error('Error:', error);
            response([]);
        });
    },

    _findInfo: function(result, type) {
      // Función _findInfo no modificada
    },

    _focusAddress: function(event, ui) {
      // Función _focusAddress no modificada
    },

    _selectAddress: function(event, ui) {
      // Función _selectAddress no modificada
    }
  });

  $.extend( $.ui.addresspicker, {
    version: "@VERSION"
  });

  // make