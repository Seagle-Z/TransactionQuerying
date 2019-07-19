package com.zero.seagle.transactionquerying;

import android.graphics.Bitmap;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;


public class MainActivity extends AppCompatActivity {

    TextView resultTextView;
    EditText postalCodeEditText;
    EditText startDateEditText;
    EditText endDateEditText;
    Button resultButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        resultTextView = (TextView)findViewById(R.id.textView_result);
        postalCodeEditText = findViewById(R.id.editText_postalCode);
        startDateEditText = findViewById(R.id.editText_startDate);
        endDateEditText = findViewById(R.id.editText_endDate);
        resultButton = (Button) findViewById(R.id.button_querying);

        resultButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                AsyncTask<String , Void ,String> gm = new GetMethod(resultTextView);
                gm.execute("https://queryingwebapi.azurewebsites.net/api/server/" +
                        startDateEditText.getText().toString() +
                        "_" + endDateEditText.getText().toString() +
                        "_" + postalCodeEditText.getText().toString() + "/");

                resultTextView.setText(((GetMethod) gm).retResponse());
                System.out.println(((GetMethod) gm).retResponse());
            }
        });



    }
}
