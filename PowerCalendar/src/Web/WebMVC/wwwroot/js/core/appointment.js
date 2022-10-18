const application = new Application();
const getPatients = async () => {
    const patients = await application.Patient.GetPatients();

    $('#modalAppointmentRegisterPatient').select2({
        data: patients
    });
}
(function ($) {
    function initSelect2() {
        $('#modalAppointmentRegisterPatient, #modalAppointmentRegisterHour').select2({
            dropdownParent: $('#modalAppointmentRegisterPartial')
        });
    }
    function initMenuAppointment() {
        $('#menuAppointment').on('click', function (e) {
            showModal();
        });
    }
    function showModal() {
        $('#modalAppointmentRegisterPartial').modal('show');
    }
    function closeModal() {
        $('#modalAppointmentRegisterPartial').modal('hide');
    }
    function initDatePicker() {
        $('#modalAppointmentRegisterDatepicker').datepicker({
            format: 'dd/mm/yyyy',
            language: 'pt-BR'
        });
    }
    function initSave() {
        $('#modalAppointmentRegisterSave').on('click', function (e) {
            save();
            closeModal();
        });
    }
    function initTypes() {
        //$('#modalAppointmentRegisterType')[0];

        var divTypes = document.getElementById('modalAppointmentRegisterType');
        var types = ['Consulta', 'Retorno', 'Exames'];
        var check = 'checked'
        for (var i = 0; i < types.length; i++) {
            if (i > 0) {
                check = '';
            }
            var html = '<div class="form-check primary"><input type="radio" name="modalAppointmentRegisterType" id="' + types[i] + '" value="' + types[i] + '" ' + check + '><label for="' + types[i] + '">' + types[i] + '</label></div>';
            divTypes.innerHTML += html;
        }
    }
    'use strict';
    const calendar = new Calendar();
    $(document).ready(function () {
        initMenuAppointment();
        initSelect2();
        getPatients();
        initDatePicker();
        initTypes();
        initSave();
    });
    async function save() {
        var timeSelected = document.querySelector("#modalAppointmentRegisterHour");
        var datePickerSelected = document.querySelector("#modalAppointmentRegisterDatepicker");
        var patientSelected = document.querySelector("#modalAppointmentRegisterPatient");
        var typeSelected = document.querySelector('input[name=modalAppointmentRegisterType]:checked');

        console.log(datePickerSelected.value);
        console.log(patientSelected.value);
        console.log(typeSelected.value);
        console.log(timeSelected.value);

        var appointment = {
            Date: datePickerSelected.value,
            Hour: timeSelected.value
        };

        await calendar.SaveAppointment(appointment);

    }
})(window.jQuery);


