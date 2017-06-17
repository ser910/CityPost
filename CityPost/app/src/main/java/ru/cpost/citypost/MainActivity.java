package ru.cpost.citypost;

import android.app.PendingIntent;
import android.content.pm.PackageManager;
import android.location.Location;
import android.location.LocationManager;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

import java.util.List;
import java.util.Optional;

import butterknife.BindArray;
import butterknife.ButterKnife;


public class MainActivity extends AppCompatActivity {

    @BindArray(R.array.lb_from)
    private String[] fromLbList;
    @BindArray(R.array.lb_to)
    private String[] toList;
    private LocationManager locationManager;
    private List<String> providers;

    private Location location;
    private boolean setProviderFlag = false;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        if (SetupLocation()) {
            setLocation(location);
        }
        Spinner fromSpinner = ButterKnife.findById(this, R.id.from_service_type);
        fromSpinner.setAdapter(ArrayAdapter.createFromResource(this, R.array.lb_from, android.R.layout.simple_spinner_item));
        Spinner toSpinner = ButterKnife.findById(this, R.id.to_service_type);
        toSpinner.setAdapter(ArrayAdapter.createFromResource(this, R.array.lb_to, android.R.layout.simple_spinner_item));
    }



    @Override
    protected void onResume() {
        super.onResume();
        if(location == null) {
            SetProvider();
            setProviderFlag = true;
        }
    }

    @Override
    protected void onPause() {
        super.onPause();
        if(setProviderFlag) {
            RemoveProvider();
            setProviderFlag =false;
        }
    }





    private void RemoveProvider() {
        if (ActivityCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED
                && ActivityCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            // TODO: Consider calling
            //    ActivityCompat#requestPermissions
            // here to request the missing permissions, and then overriding
            //   public void onRequestPermissionsResult(int requestCode, String[] permissions,
            //                                          int[] grantResults)
            // to handle the case where the user grants the permission. See the documentation
            // for ActivityCompat#requestPermissions for more details.
            return;
        }
        //locationManager.removeUpdates(locationListener);
    }

    private void SetProvider() {
        if (ActivityCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED
                && ActivityCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            return;
        }
        PendingIntent pendingIntent = PendingIntent.getBroadcast(this, 0, getIntent(), PendingIntent.FLAG_UPDATE_CURRENT);
        locationManager.requestSingleUpdate(providers.get(0), pendingIntent);
    }


    private void setLocation(Location location) {

    }

    private boolean SetupLocation() {
        locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
        providers = locationManager.getProviders(true);
        if (providers.isEmpty()) {
            new LocationDialog().show(getSupportFragmentManager(), "dialog");
        }
        if (ActivityCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED
                && ActivityCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            return false;
        }
        Optional<String> provider = providers.stream()
                .filter(p -> locationManager.getLastKnownLocation(p) != null)
                .max((p1,p2)-> Long.compare(
                        locationManager.getLastKnownLocation(p1).getTime(),
                        locationManager.getLastKnownLocation(p2).getTime()
                ));
        if(provider.isPresent()) {
            location = locationManager.getLastKnownLocation(provider.get());
        }
        return true;
    }

}
