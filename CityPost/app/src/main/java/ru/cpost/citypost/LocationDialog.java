package ru.cpost.citypost;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;
import android.widget.Toast;

/**
 * Created by Sergey Degtyar on 05.03.2017.
 */

public class LocationDialog extends DialogFragment {
    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        // заголовок
        builder.setTitle(R.string.error);
        // сообщение
        builder.setMessage(R.string.location_error);
        // иконка
        builder.setIcon(android.R.drawable.ic_dialog_info);
        // кнопка положительного ответа
        builder.setPositiveButton(R.string.yes, locationErrClickListener);
        // кнопка отрицательного ответа
        builder.setNegativeButton(R.string.no, locationErrClickListener);
        // создаем диалог
        return builder.create();
    }

    DialogInterface.OnClickListener locationErrClickListener = new DialogInterface.OnClickListener() {
        public void onClick(DialogInterface dialog, int which) {
            switch (which) {
                // положительная кнопка
                case Dialog.BUTTON_POSITIVE:
                    startActivity(new Intent(
                            android.provider.Settings.ACTION_LOCATION_SOURCE_SETTINGS));
                    break;
                // негативная кнопка
                case Dialog.BUTTON_NEGATIVE:
                    Toast.makeText(getActivity(), R.string.apologize, Toast.LENGTH_LONG).show();
                    getActivity().finish();
                    break;
            }
        }
    };
}
